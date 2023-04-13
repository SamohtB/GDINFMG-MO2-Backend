from py_unite_db import UniteDb
import json

unite_db = UniteDb()

for item in unite_db.battle_items:
    
    element = {
        "name" : item.name, 
        "CD" : item.cooldown, 
        "description" : item.description,
        }
    print(json.dumps(element))

