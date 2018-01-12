require 'json' 

json_string = '{"x": 0, "y": 0,
                "Arr": [{"start": {"x": 0, "y": 0}, "end": {"x": 10000, "y": 10000}},
                        {"start": {"x": 5000, "y": -10000}, "end": {"x": 5000, "y": 10000}},
                        {"start": {"x": 5000, "y": 10000}, "end": {"x": 10000, "y": 10000}}]}'
my_hash = JSON.parse(json_string) 
puts my_hash["Arr"]
