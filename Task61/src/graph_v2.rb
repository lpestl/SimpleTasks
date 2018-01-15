require 'json'

# Считаем и получаем длинну дороги от точки point1 до точки point2
def get_distance(x1, y1, x2, y2)
  Math.sqrt((x2 - x1)**2 + (y2 - y1)**2)
end

# Основная функция подсчета минимального времени
def get_min_time(input_json, speed)
  data_hash = JSON.parse(input_json)
  distance = 0
  data_hash["Arr"].each{ |road| distance += 2 * get_distance(road["start"]["x"], road["start"]["y"], road["end"]["x"], road["end"]["y"])}
  min_time = (distance / (speed * 1000 / 60)).round
  min_time
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
puts get_min_time(json_string, SPEED)

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

puts get_min_time(json_string, SPEED)

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

puts get_min_time(json_string, SPEED)
