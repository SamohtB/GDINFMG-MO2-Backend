DROP SCHEMA IF EXISTS pokemon_unite;
CREATE SCHEMA IF NOT EXISTS pokemon_unite;

USE pokemon_unite;

CREATE TABLE IF NOT EXISTS Pokemon
(
	pokemonid INT NOT NULL UNIQUE AUTO_INCREMENT,
    name VARCHAR(12) NOT NULL UNIQUE,
    sprite BLOB,
    attacktype ENUM('PHYSICAL','SPECIAL') NOT NULL,
	attackstyle ENUM('MELEE', 'RANGED') NOT NULL,
    role ENUM('Attacker', 'Defender', 'All-Rounder', 'Supporter', 'Speedster') NOT NULL,
    complexity ENUM('Novice', 'Intermediate', 'Expert') NOT NULL,
    stats INT,
	CONSTRAINT `pokemon_pk_name` PRIMARY KEY (pokemonid)
);

CREATE TABLE IF NOT EXISTS Stats
(
    ownerid INT NOT NULL,
    level INT NOT NULL,
    HP INT NOT NULL,
    ATK INT NOT NULL,
    DEF INT NOT NULL,
    SpA INT NOT NULL,
    SpD INT NOT NULL,
    criticalrate FLOAT NOT NULL,
    cooldownredux FLOAT NOT NULL,
    lifesteal FLOAT NOT NULL,
    attackspeed FLOAT,
    CONSTRAINT `stats_pk_owner&level` PRIMARY KEY (ownerid, level),
    CONSTRAINT `stats_fk_owner` FOREIGN KEY (ownerid) REFERENCES Pokemon (pokemonid)
);

CREATE TABLE IF NOT EXISTS Skill
(
	ownerid INT NOT NULL,
    name VARCHAR(40) NOT NULL,
    skilltype ENUM('Ranged', 'Melee', 'Area', 'Hindrance', 'Dash', 'Buff', 'Debuff', 'Recovery', 'SureHit'),
    skillclass ENUM('Basic', 'Passive', 'Move1', 'Move2', 'Unite') NOT NULL,
    levelrequirement INT NOT NULL,
    cooldown INT,
    statuseffect ENUM('Slow', 'Stun', 'Burn', 'Sleep', 'Buff', 'Heal'),
    skilltext TEXT NOT NULL,
    attacktype ENUM('PHYSICAL','SPECIAL'),
    attackmultiplier FLOAT,
	basemultiplier INT,
    basedamage INT,
    CONSTRAINT `skill_pk_owner&name` PRIMARY KEY (ownerid, name),
    CONSTRAINT `skill_fk_owner` FOREIGN KEY (ownerid) REFERENCES Pokemon (pokemonid)
);

CREATE TABLE IF NOT EXISTS HeldItem
(
	heldid INT NOT NULL UNIQUE AUTO_INCREMENT,
	name VARCHAR(20) NOT NULL UNIQUE,
    sprite BLOB,
    tierlevel ENUM('1', '10', '20', '30') NOT NULL,
    tierattribtype ENUM('HP', 'ATK', 'DEF', 'SpA',  'SpD', 'MS',  'CritRate', 'CDR') NOT NULL,
    tierval FLOAT NOT NULL,
    attribtype1 ENUM('HP', 'ATK', 'DEF', 'SpA',  'SpD', 'MS',  'CritRate', 'CDR') NOT NULL,
    attribval1 FLOAT NOT NULL,
    attribtype2 ENUM('HP', 'ATK', 'DEF', 'SpA',  'SpD', 'MS',  'CritRate', 'CDR'),
    attribval2 FLOAT,
    description TEXT NOT NULL,
    CONSTRAINT `helditem_pk_id` PRIMARY KEY (heldid)
);

CREATE TABLE IF NOT EXISTS BattleItem
(
	battleid INT NOT NULL UNIQUE AUTO_INCREMENT,
	name VARCHAR(20) NOT NULL UNIQUE,
    sprite BLOB,
    cooldown FLOAT NOT NULL,
    description TEXT NOT NULL,
    CONSTRAINT `battleitem_pk_id` PRIMARY KEY (battleid)
);

CREATE TABLE IF NOT EXISTS BoostEmblem
(
	emblemid INT NOT NULL UNIQUE AUTO_INCREMENT,
	name VARCHAR(12) NOT NULL,
    sprite BLOB, 
    Color1 ENUM('Blue','Grey') NOT NULL,
    Color2 ENUM('Blue', 'Grey'),
    emblemtier ENUM('Bronze', 'Silver', 'Gold') NOT NULL,
    AttribType1 ENUM('HP', 'ATK', 'DEF', 'SpA',  'SpD', 'MS',  'CritRate', 'CDR') NOT NULL,
    AttribVal1 FLOAT NOT NULL,
    AttribType2 ENUM('HP', 'ATK', 'DEF', 'SpA',  'SpD', 'MS',  'CritRate', 'CDR'),
    AttribVal2 FLOAT,
    CONSTRAINT `boostemblem_pk_id` PRIMARY KEY (emblemid)
);

CREATE TABLE IF NOT EXISTS EmblemLoadout
(
	loadoutid INT NOT NULL UNIQUE AUTO_INCREMENT,
    name VARCHAR(30) NOT NULL,
    CONSTRAINT `emblemloadout_pk_id` PRIMARY KEY (loadoutid)
);

CREATE TABLE IF NOT EXISTS EmblemSlot
(
	loadoutid INT NOT NULL,
    emblemid INT NOT NULL,
    CONSTRAINT `slot_pk_owner&emblem` PRIMARY KEY (loadoutid, emblemid),
    CONSTRAINT `slot_fk_owner` FOREIGN KEY (loadoutid) REFERENCES EmblemLoadout(loadoutid),
    CONSTRAINT `slot_fk_emblem` FOREIGN KEY (emblemid) REFERENCES BoostEmblem(emblemid)
);

CREATE TABLE IF NOT EXISTS PokemonBuild
(
	ownerid INT NOT NULL,
    name VARCHAR(30) NOT NULL,
    move1 VARCHAR(40) NOT NULL,
    move2 VARCHAR(40) NOT NULL,
    helditemid1 INT,
    helditemid2 INT,
    helditemid3 INT,
    battleitemid INT NOT NULL DEFAULT(0),
    loadout INT,
    CONSTRAINT `build_pk_owner&name` PRIMARY KEY (ownerid, name),
    CONSTRAINT `build_fk_owner` FOREIGN KEY (ownerid) REFERENCES Pokemon(pokemonid),
    CONSTRAINT `build_fk_move1` FOREIGN KEY (ownerid, move1) REFERENCES Skill(ownerid, name),
    CONSTRAINT `build_fk_move2` FOREIGN KEY (ownerid, move2) REFERENCES  Skill(ownerid, name),
    CONSTRAINT `build_fk_held1` FOREIGN KEY (helditemid1) REFERENCES HeldItem(heldid),
    CONSTRAINT `build_fk_held2` FOREIGN KEY (helditemid2) REFERENCES HeldItem(heldid),
    CONSTRAINT `build_fk_held3` FOREIGN KEY (helditemid3) REFERENCES HeldItem(heldid),
    CONSTRAINT `build_fk_battle`FOREIGN KEY (battleitemid) REFERENCES BattleItem(battleid),
    CONSTRAINT `build_fk_loadout` FOREIGN KEY (loadout) REFERENCES EmblemLoadout(loadoutid)
);



