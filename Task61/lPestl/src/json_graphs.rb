require 'json'

# Идея заключается в следующем алгоритме, с учетом того, что гараж и тупики будем считать перекрестками:
# 1) Выезжаем от гаража, обрабатываем одну полосу дороги;
# 2) Доезжаем до перекрестка и смотрим на дороги, которые здесь пересекаются.
# 3) Если на этом перекрестке есть хотябы одна дорога, не обработанная ни по одной полосе,
#    4) то мы едем по ней, обрабатывая полосу,
#    5) иначе мы возвращаемся на прошлый перекресток, обрабатывая вторую полосу дороги
# 6) Повторить шаг 2, до тех пор, пока
#    этот перекресток не окажется гаражом И от гаража больше нет необработанных дорог

# Так же обговорим структуры хранения данных.
# Создадим структуру Point (x, y) для удобного хранения и сравнения координат.
# Создадим класс "Перекресток (Crossroad)", который будет включать в себя координаты расположения,
#   массив для хранения всех исходящих полос движения от этого перекрестка к следующим, которые еще не были обработаны (out_roads)
#   и массив для хранения всех входящих полос движения к этому перекрестку от других перекрестков (in_roads).

# структура координат
Point = Struct.new('Point', :x, :y)

# класс "Перекресток". Поля класса это:
#   location  - расположение перекрестка в координатах
#   in_road   - массив координат перекрестков, из которых можно попасть на этот перекресток
#   out_road  - массив координат перекрестков, в которык можно попасть из этого перекрестка
class Crossroad
  attr_accessor :location, :in_roads, :out_roads

  def initialize(location)
    @location = location
  end
end

# Основная функция обхода графа. Считает и возвращает минимальное время, необходимое для обработки всех дорог
class Solver
  attr_reader :data_hash, :speed

  def initialize(input_json, speed)
    @speed = speed
    # Создаем хэш карту из json строки
    @data_hash = JSON.parse(input_json)
  end

  def min_time
    @min_time ||= calculate!
  end

  private

  def calculate!
    # Создаем из заполняем массив, хранящий в себе все перекрестки
    crossroads = [Crossroad.new(Point.new(data_hash['x'], data_hash['y']))]
    get_in_out_roads(crossroads[0], data_hash)

    i = 0
    while i < data_hash['Arr'].count
      find_crossroad_in_data_hash(data_hash, i, 'start', crossroads)
      find_crossroad_in_data_hash(data_hash, i, 'end', crossroads)
      i += 1
    end

    # Создаем массив по аналогии со стеком, который будет хранить в себе пройденные перекрестки
    way = [crossroads[0]]

    # Счетчик для пройденной дистанции
    distance = 0
    # Индекс для стека пройденного пути
    curr_cross_i = 0
    while way.count > 0
      # untreated - результат пересечения множеств in_roads и out_roads
      # другими словами, ищем все дороги, идущие от текущего перекрестка, которые не были обработаны ни по одной полосе
      untreated = way[curr_cross_i].in_roads & way[curr_cross_i].out_roads
      # если такие дороги есть, то едем по любой из них до перекрестка, обрабатывая полосу
      if untreated.count > 0
        # находим первый перекресток дорого к которому не обрабатывалась, от текущего перекрестка
        next_cross = crossroads.find { |x| x.location == untreated[0] }
        # считаем расстояние до него
        distance += get_distance(way[curr_cross_i].location, next_cross.location)
        # и удаляем одну полосу из массивов необработанных полос дорог
        way[curr_cross_i].out_roads.delete(next_cross.location)
        next_cross.in_roads.delete(way[curr_cross_i].location)
        # и перемещаемся на новый перекресток
        way.push(next_cross)
        curr_cross_i += 1
      # иначе нужно вернуться к предыдущему перекрестку, обрабатывая вторую полосу
      else
        # запоминаем координаты прошлого перекрестка и текущего
        back = way[curr_cross_i].out_roads.find { |x| x == way[curr_cross_i - 1].location }
        curr = way[curr_cross_i].location
        # удаляем из массивов необработанных полос, ту полосу которую обрабатываем сейчас
        way[curr_cross_i].out_roads.delete(back)
        way[curr_cross_i - 1].in_roads.delete(curr)
        # и перемещаемся к прошлому перекрестку
        way.pop
        curr_cross_i -= 1
        # Если мы еще не в гараже, то считаем пройденное расстояние
        distance += get_distance(back, curr) if way.count > 0
      end
    end

    # Считаем затраченное время в минутах и округляем его до целого
    @min_time = (distance / (speed * 1000 / 60)).round
  end

  # Функция находит и добавляет ВСЕ соседние перекрестки из json данных для текущего перекрестка cross (инициализация перекрестка)
  def get_in_out_roads(cross, data_hash)
    # Находим и добавляем соседние перекрестки из элемента Arr в json данных, для текущего перекрестка cross
    find_in_out_roads = lambda do |cross, data_hash, row, from:, to:|
      if data_hash['Arr'][row][from]['x'] == cross.location.x &&
         data_hash['Arr'][row][from]['y'] == cross.location.y
        end_road = Point.new(data_hash['Arr'][row][to]['x'], data_hash['Arr'][row][to]['y'])
        cross.in_roads.push(end_road)
        cross.out_roads.push(end_road)
      end
    end

    i = 0
    cross.in_roads = []
    cross.out_roads = []
    while i < data_hash['Arr'].count
      find_in_out_roads.call(cross, data_hash, i, from: 'start', to: 'end')
      find_in_out_roads.call(cross, data_hash, i, from: 'end', to: 'start')
      i += 1
    end
  end

  # Функция заполняет массив crossroads всеми перекрестками без повторений
  def find_crossroad_in_data_hash(data_hash, row, where, crossroads)
    location = Point.new(data_hash['Arr'][row][where]['x'], data_hash['Arr'][row][where]['y'])
    return if crossroads.any? { |x| x.location == location }
    new_cross = Crossroad.new(location)
    get_in_out_roads(new_cross, data_hash)
    crossroads.push(new_cross)
  end

  # Считаем и получаем длинну дороги от точки point1 до точки point2
  def get_distance(point1, point2)
    Math.sqrt((point2.x - point1.x)**2 + (point2.y - point1.y)**2)
  end
end

# скорость при обратке дороги
SPEED = 20 # км / ч
# данные о координатах гаража и всех дорогах
# TEST 1:
#            _
#           |/
#          /|
#
json_string = <<~JSON
  {
    "x" : 0, "y" : 0,
    "Arr" : [
      { "start": { "x" : 0, "y" : 0 }, "end": { "x" : 10000, "y" : 10000 }},
      { "start": { "x" : 5000, "y" : -10000 }, "end": { "x" : 5000, "y": 10000 }},
      { "start": { "x" : 5000, "y" : 10000 }, "end": { "x" : 10000, "y" : 10000 }}
    ]
  }
JSON

# Вызов функции подсчета минимального времени и вывод на экран
puts Solver.new(json_string, SPEED).min_time

# TEST 2:
#             
#           /|\
#          --+--
#           \|/
#
json_string = <<~JSON
  {
    "x" : 0, "y" : 0,
    "Arr" : [
      { "start": { "x" : 0, "y" : 0 }, "end": { "x" : 5000, "y" : 5000 }},
      { "start": { "x" : 5000, "y" : 5000 }, "end": { "x" : 10000, "y": 0 }},
      { "start": { "x" : 0, "y" : 0 }, "end": { "x" : 5000, "y": -5000 }},
      { "start": { "x" : 5000, "y" : -5000 }, "end": { "x" : 10000, "y": 0 }},
      { "start": { "x" : 0, "y" : 0 }, "end": { "x" : 10000, "y": 0 }},
      { "start": { "x" : 5000, "y" : 5000 }, "end": { "x" : 5000, "y" : -5000 }}
    ]
  }
JSON

puts Solver.new(json_string, SPEED).min_time

# TEST 3:
#           | |
#          -+-+-
#           | |
#          -+-+-
#           | |
#
json_string = <<~JSON
  {
    "x" : 0, "y" : 0,
    "Arr" : [
      { "start": { "x" : 0, "y" : 0 }, "end": { "x" : 5000, "y" : 0 }},
      { "start": { "x" : 5000, "y" : 0 }, "end": { "x" : 10000, "y": 0 }},
      { "start": { "x" : 10000, "y" : 0 }, "end": { "x" : 15000, "y": 0 }},
      { "start": { "x" : 0, "y" : -5000 }, "end": { "x" : 5000, "y": -5000 }},
      { "start": { "x" : 5000, "y" : -5000 }, "end": { "x" : 10000, "y": -5000 }},
      { "start": { "x" : 10000, "y" : -5000 }, "end": { "x" : 15000, "y": -5000 }},
      { "start": { "x" : 5000, "y" : 5000 }, "end": { "x" : 5000, "y" : 0 }},
      { "start": { "x" : 5000, "y" : 0 }, "end": { "x" : 5000, "y": -5000 }},
      { "start": { "x" : 5000, "y" : -5000 }, "end": { "x" : 5000, "y": -10000 }},
      { "start": { "x" : 10000, "y" : 5000 }, "end": { "x" : 10000, "y": 0 }},
      { "start": { "x" : 10000, "y" : 0 }, "end": { "x" : 10000, "y": -5000 }},
      { "start": { "x" : 10000, "y" : -5000 }, "end": { "x" : 10000, "y" : -10000 }}
    ]
  }
JSON

puts Solver.new(json_string, SPEED).min_time