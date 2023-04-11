USE pokemon_unite;

describe Pokemon;
describe Stats;
describe Skill;
describe HeldItem;
describe BattleItem;

/* test pokemon */
INSERT INTO Pokemon(name, attacktype, attackstyle, role, complexity)
VALUES ("Ninetails", 'Special', 'Ranged', 'Attacker', 'Intermediate');

SELECT * FROM Pokemon;

/* test stats */
INSERT INTO Stats(ownerid, level, HP, ATK, DEF, SpA, SpD, criticalrate, cooldownredux, lifesteal, attackspeed)
VALUES (1, 1, 9000, 200, 300, 1000, 500, 0.0, 0.25, 0.0, 1.0),
(1, 2, 10000, 250, 350, 1100, 550, 0.0, 0.3, 0.0, 1.1);

/* test skills */
INSERT INTO Skill(ownerid, name, skilltype, skillclass, levelrequirement, cooldown, statuseffect, skilltext, attacktype, attackmultiplier, basemultiplier, basedamage)
VALUES (1, "Dazzling Gleam", 'Hindrance', 'Move1', 4, 5.0, 'Stun', "Hello World", 'SPECIAL', 0.67, 13, 120),
(1, "Snow Warning", NULL, 'Passive', 1, 8.0, 'Slow', "Causes snow to fall on an enemy, dealing damage to it and decreasing 
their movement speed by 30% for .75s. Boosted attacks, Snow Warning, and all moves (except Aurora Veil) sling snow; hitting the same 
target with snow 4 times will freeze them for 1s. This ability has an 8s cooldown.", NULL, NULL, NULL, NULL);

INSERT INTO battleItem(name, cooldown, description)
VALUES ("Potion", 50.0, "Heal for 10");

INSERT INTO PokemonBuild(ownerid, name, move1, move2, battleitemid)
VALUES (1, "Dazzling Veil!", "Dazzling Gleam", "Snow Warning", 1);

SELECT * FROM Pokemon
INNER JOIN Stats ON Pokemon.pokemonid = Stats.ownerid;

SELECT * FROM Skill
WHERE ownerid = 1;

SELECT * FROM PokemonBuild
WHERE ownerid = 1;