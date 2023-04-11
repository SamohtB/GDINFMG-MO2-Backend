from py_unite_db import UniteDb
import json

unite_db = UniteDb()

pokemon_list = []

for pokemon in unite_db.pokemon:
    
    element = {
        "name" : pokemon.name,
        "attack_type" : pokemon.damage_type,
        "attack_style" : pokemon.range,
        "role" : pokemon.role,
        "complexity" : pokemon.difficulty 
    }

    print(json.dumps(element))
