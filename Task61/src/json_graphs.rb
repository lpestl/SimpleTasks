require 'json'

# структура координат
Struct.new("Point", :x, :y)

# класс "Перекресток". Поля класса это:
#   location  - расположение перекрестка в координатах
#   in_road   - массив координат перекрестков, из которых можно попасть на этот перекресток
#   out_road  - массив координат перекрестков, в которык можно попасть из этого перекрестка
class Crossroad
  attr_accessor :location,
     :in_roads,
     :out_roads
end

# Основная функция обхода графа. Считает и возвращает минимальное время, необходимое для обработки всех дорог
def get_min_time(input_json, speed)
  # Создаем хэш карту из json строки
  data_hash = JSON.parse(input_json)
  
  # Функция находит и добавляет ВСЕ соседние перекрестки из json данных для текущего перекрестка cross (инициализация перекрестка)
  def get_in_out_roads(cross, data_hash)
    # Находим и добавляем соседние перекрестки из элемента Arr в json данных, для текущего перекрестка cross
    def find_in_out_roads(cross, data_hash, row, from, to)
      if data_hash["Arr"][row][from]["x"] == cross.location.x &&
          data_hash["Arr"][row][from]["y"] == cross.location.y
            end_road = Struct::Point.new(data_hash["Arr"][row][to]["x"], data_hash["Arr"][row][to]["y"])
            cross.in_roads.push(end_road)
            cross.out_roads.push(end_road)
      end
    end
    
    i=0
    cross.in_roads = Array.new
    cross.out_roads = Array.new
    while i < data_hash["Arr"].count
      find_in_out_roads(cross, data_hash, i, "start", "end")
      find_in_out_roads(cross, data_hash, i, "end", "start")
      i+=1
    end
  end
  
  # Создаем из заполняем массив, хранящий в себе все перекрестки
  crossroads = Array.new
  crossroads.push(Crossroad.new)
  crossroads[0].location = Struct::Point.new(data_hash["x"], data_hash["y"])
  get_in_out_roads(crossroads[0], data_hash)
  
  # Функция заполняет массив crossroads всеми перекрестками без повторений
  def find_crossroad_in_data_hash(data_hash, row, where, crossroads)
    location = Struct::Point.new(data_hash["Arr"][row][where]["x"], data_hash["Arr"][row][where]["y"])
    cross = crossroads.find{ |x| x.location == location}
    if cross == nil 
      new_cross = Crossroad.new
      new_cross.location = location
      get_in_out_roads(new_cross, data_hash)
      crossroads.push(new_cross)
    end
  end
  
  i = 0
  while i < data_hash["Arr"].count
    find_crossroad_in_data_hash(data_hash, i, "start", crossroads)
    find_crossroad_in_data_hash(data_hash, i, "end", crossroads)
    i += 1
  end

  # Создаем массив по аналогии со стеком, который будет хранить в себе пройденные перекрестки
  way = Array.new
  way.push(crossroads[0])
  
  # Считаем и получаем длинну дороги от точки point1 до точки point2
  def get_distance(point1, point2)
    Math.sqrt((point2.x - point1.x)**2 + (point2.y - point1.y)**2)
  end
  
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
      next_cross = crossroads.find{|x| x.location == untreated[0]}
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
      back = way[curr_cross_i].out_roads.find{|x| x == way[curr_cross_i-1].location}
      curr = way[curr_cross_i].location
      # удаляем из массивов необработанных полос, ту полосу которую обрабатываем сейчас
      way[curr_cross_i].out_roads.delete(back)
      way[curr_cross_i-1].in_roads.delete(curr)
      # и перемещаемся к прошлому перекрестку
      way.pop
      curr_cross_i -= 1
      # Если мы еще не в гараже, то считаем пройденное расстояние
      if way.count > 0
        distance += get_distance(back, curr)
      end
    end
  end
  
  # Считаем затраченное время в минутах и округляем его до целого
  min_time = distance / (speed * 1000 / 60)
  min_time.round
end

# скорость при обратке дороги
speed = 20    # км / ч
# данные о координатах гаража и всех дорогах
# TEST 1:
#            _
#           |/
#          /|
#
json_string = '{"x" : 0, "y" : 0,  
    "Arr" : [   
      { "start": { "x" : 0, "y" : 0 }, "end": { "x" : 10000, "y" : 10000 }},  
      { "start": { "x" : 5000, "y" : -10000 }, "end": { "x" : 5000, "y": 10000 }},    
      { "start": { "x" : 5000, "y" : 10000 }, "end": { "x" : 10000, "y" : 10000 }}]}'

# Вызов функции подсчета минимального времени и вывод на экран
puts get_min_time(json_string, speed)

# TEST 2:
#            _
#           /|\
#          --+--
#           \|/
#
json_string = '{"x" : 0, "y" : 0,  
    "Arr" : [   
      { "start": { "x" : 0, "y" : 0 }, "end": { "x" : 5000, "y" : 5000 }},  
      { "start": { "x" : 5000, "y" : 5000 }, "end": { "x" : 10000, "y": 0 }}, 
      { "start": { "x" : 0, "y" : 0 }, "end": { "x" : 5000, "y": -5000 }},   
      { "start": { "x" : 5000, "y" : -5000 }, "end": { "x" : 10000, "y": 0 }}, 
      { "start": { "x" : 0, "y" : 0 }, "end": { "x" : 10000, "y": 0 }},  
      { "start": { "x" : 5000, "y" : 5000 }, "end": { "x" : 5000, "y" : -5000 }}]}'

puts get_min_time(json_string, speed)

# TEST 3:
#           | |
#          -+-+-
#           | |
#          -+-+-
#           | |
#
json_string = '{"x" : 0, "y" : 0,  
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
      { "start": { "x" : 10000, "y" : -5000 }, "end": { "x" : 10000, "y" : -10000 }}]}'

puts get_min_time(json_string, speed)
