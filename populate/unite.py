from py_unite_db import UniteDb
import json

unite_db = UniteDb()

entity_list = []

for pokemon in unite_db.pokemon:
    
    print("(" + pokemon.name + ", " + pokemon.damage_type + ", " + pokemon.range + ", " + 
          pokemon.role + ", " + pokemon.difficulty + ")")