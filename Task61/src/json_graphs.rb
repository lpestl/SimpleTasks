require 'json'

Struct.new("Point", :x, :y)

class Crossroad
  attr_accessor :location,
     :in_roads,
     :out_roads
end

def find_in_out_roads_in_json_data(cross, data_hash, row, from, to)
  if data_hash["Arr"][row][from]["x"] == cross.location.x &&
      data_hash["Arr"][row][from]["y"] == cross.location.y
        end_road = Struct::Point.new(data_hash["Arr"][row][to]["x"], data_hash["Arr"][row][to]["y"])
        cross.in_roads.push(end_road)
        cross.out_roads.push(end_road)
  end
end

def get_in_out_roads(cross, data_hash)
  i=0
  cross.in_roads = Array.new
  cross.out_roads = Array.new
  while i < data_hash["Arr"].count
    find_in_out_roads_in_json_data(cross, data_hash, i, "start", "end")
    find_in_out_roads_in_json_data(cross, data_hash, i, "end", "start")
    i+=1
  end
end

def does_its_cross_exist(point, *crossroads)
  res = false
  i = 0
  while i < crossroads.count
    if crossroads[i].location == point
      res = true
      break
    end
    i += 1
  end
  res
end

def find_crossroad_in_json_data(data_hash, row, where, *crossroads)
  location = Struct::Point.new(data_hash["Arr"][row][where]["x"], data_hash["Arr"][row][where]["y"])
  if does_its_cross_exist(location, *crossroads) == false 
    puts "Crossroad (#{location.x}, #{location.y}) is not exist"
    new_cross = Crossroad.new
    new_cross.location = location
    get_in_out_roads(new_cross, data_hash)
    crossroads.push(new_cross)
  else
    puts "Crossroad (#{location.x}, #{location.y}) is exist. Next location."
  end
end

def get_min_time(input_json)
  data_hash = JSON.parse(input_json)
  
  crossroads = Array.new
  crossroads.push(Crossroad.new)
  crossroads[0].location = Struct::Point.new(data_hash["x"], data_hash["y"])
  get_in_out_roads(crossroads[0], data_hash)
  i = 0
  while i < data_hash["Arr"].count
    find_crossroad_in_json_data(data_hash, i, "start", *crossroads)
    find_crossroad_in_json_data(data_hash, i, "end", *crossroads)
    i += 1
  end

  i = 0
  while i < crossroads.count
    puts "Crossroad location is x:#{crossroads[i].location.x} y:#{crossroads[i].location.y}"
    i += 1
  end
  
=begin  
  way = Array.new
  way.push(Crossroad.new)
  way[0].location = Struct::Point.new(data_hash["x"], data_hash["y"])
  get_in_out_roads(way[0], data_hash)
=end
  
  curr_cross = 0
=begin
  while way.count > 0 
    puts "-----------------"
    puts "Current crossroad is #{curr_cross} (#{way[curr_cross].location.x}, #{way[curr_cross].location.y})"
    untreated = way[curr_cross].in_roads & way[curr_cross].out_roads
    if untreated.count > 0
      curr_cross += 1
      way.push(Crossroad.new)
      way[curr_cross].location = untreated[0]
    else
      curr_cross -= 1
      way.pop
    end
  end
=end
end

json_string = '{"x" : 0, "y" : 0,  
    "Arr" : [   
      { "start": { "x" : 0, "y" : 0 }, "end": { "x" : 10000, "y" : 10000 }},  
      { "start": { "x" : 5000, "y" : -10000 }, "end": { "x" : 5000, "y": 10000 }},    
      { "start": { "x" : 5000, "y" : 10000 }, "end": { "x" : 10000, "y" : 10000 }}]}'

puts get_min_time(json_string)