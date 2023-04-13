use pokemon_unite;

SELECT * FROM Pokemon;
SELECT * FROM Stats;
SELECT * FROM BattleItem;
SELECT * FROM HeldItem;
SELECT * FROM PokemonBuild;
SELECT * FROM Skill;

SELECT * FROM Pokemon JOIN Stats ON Pokemon.pokemonid = Stats.ownerid;
