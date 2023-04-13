from py_unite_db import UniteDb
import json

unite_db = UniteDb()

index = 1

for pokemon in unite_db.pokemon:
    
    if pokemon.name != "Scyther":
        for level in range(15):
            element = {
                "ownerid" : index, 
                "level" : level + 1, 
                "HP" : pokemon.stats_at(level + 1).hp,
                "ATK" : pokemon.stats_at(level + 1).attack,
                "DEF" : pokemon.stats_at(level + 1).defense,
                "SpA" : pokemon.stats_at(level + 1).sp_attack,
                "SpD" : pokemon.stats_at(level + 1).sp_defense,
                "criticalrate" : pokemon.stats_at(level + 1).crit,
                "cooldownredux" : pokemon.stats_at(level + 1).cooldown_reduction, 
                "lifesteal" : pokemon.stats_at(level + 1).lifesteal
            }
            print(json.dumps(element))
        
        index += 1
