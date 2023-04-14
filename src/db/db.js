const mysql = require('mysql2/promise');
require("dotenv").config();

const pool = mysql.createPool({
    host: process.env.SQL_HOST,
    user: 'root',
    password: process.env.SQL_PASSWORD,
    database: process.env.SQL_DB,
});

//Route 1 - All Pokemon
function GetAllPokemon() 
{
    const stmt = `SELECT pokemonid, sprite, name FROM Pokemon`;
    console.log("sent query: " + stmt);
    return pool.query(stmt);
}

//Route 2 - Filtered Pokemon
function GetFilteredPokemon(values) 
{
    filterParams = [];

    let typestmt = '';
    if(values[0] != 'NULL')
    {
        typestmt = ` WHERE P2.attacktype = ?`;
        filterParams.push(values[0]);
    }

    let stylestmt = '';
    if(values[1] != 'NULL')
    {
        stylestmt = `WHERE P3.attackstyle = ?`;
        filterParams.push(values[1]);
    }

    let rolestmt = '';
    if(values[2] != 'NULL')
    {
        rolestmt = `WHERE P4.role = ?`;
        filterParams.push(values[2]);
    }

    let complexstmt = '';
    if(values[3] != 'NULL')
    {
        complexstmt = `WHERE P5.complexity = ?`;
        filterParams.push(values[3]);
    }

    const basestmt = `SELECT P1.pokemonid, P1.sprite, P1.name FROM Pokemon P1 WHERE 
                        P1.pokemonid IN (SELECT P2.pokemonid FROM pokemon P2 ${typestmt}) AND
                        P1.pokemonid IN (SELECT P3.pokemonid FROM pokemon P3 ${stylestmt}) AND
                        P1.pokemonid IN (SELECT P4.pokemonid FROM pokemon P4 ${rolestmt}) AND
                        P1.pokemonid IN (SELECT P5.pokemonid FROM pokemon P5 ${complexstmt})`;

    console.log("sent query: " + basestmt);
    return pool.query(basestmt, filterParams);
}

//Route 2 - Filtered Pokemon Count
function GetFilteredPokemonCount(values)
{
    filterParams = [];

    let typestmt = '';
    if(values[0] != 'NULL')
    {
        typestmt = ` WHERE P2.attacktype = ?`;
        filterParams.push(values[0]);
    }

    let stylestmt = '';
    if(values[1] != 'NULL')
    {
        stylestmt = `WHERE P3.attackstyle = ?`;
        filterParams.push(values[1]);
    }

    let rolestmt = '';
    if(values[2] != 'NULL')
    {
        rolestmt = `WHERE P4.role = ?`;
        filterParams.push(values[2]);
    }

    let complexstmt = '';
    if(values[3] != 'NULL')
    {
        complexstmt = `WHERE P5.complexity = ?`;
        filterParams.push(values[3]);
    }

    const basestmt = `SELECT COUNT (P1.pokemonid) FROM Pokemon P1 WHERE 
                        P1.pokemonid IN (SELECT P2.pokemonid FROM pokemon P2 ${typestmt}) AND
                        P1.pokemonid IN (SELECT P3.pokemonid FROM pokemon P3 ${stylestmt}) AND
                        P1.pokemonid IN (SELECT P4.pokemonid FROM pokemon P4 ${rolestmt}) AND
                        P1.pokemonid IN (SELECT P5.pokemonid FROM pokemon P5 ${complexstmt})`;
    console.log("sent query: " + basestmt);
    return pool.query(basestmt, filterParams);
}

//Route 3 - Specific Pokemon With Stats and Skills
function GetPokemon(values)
{
    const stmt = `SELECT * FROM Pokemon WHERE pokemonid = ?`;
    console.log("sent query: " + stmt);
    return pool.query(stmt, values);
}

//Route 3
function GetSkills(values)
{
    const stmt = `SELECT * FROM Skill WHERE ownerid = ?`;
    console.log("sent query: " + stmt);
    return pool.query(stmt, values);
}

//Route 3
function GetStats(values)
{
    const stmt = `SELECT * FROM Stats WHERE ownerid = ?`;
    console.log("sent query: " + stmt);
    return pool.query(stmt, values);
}

//Route 4
function GetAllBattleItems()
{
    //Add sprite later
    const stmt = `SELECT battleid, sprite, name FROM BattleItem`;
    console.log("sent query: " + stmt);
    return pool.query(stmt);
}

//Route 4
function GetAllHeldItems()
{
    //Add sprite later
    const stmt = `SELECT heldid, sprite, name FROM HeldItem`;
    console.log("sent query: " + stmt);
    return pool.query(stmt);
}

//Route 5
function GetBattleItem(values)
{
    const stmt = `SELECT * FROM BattleItem WHERE battleid = ?`;
    return pool.query(stmt, values);
}

//Route 6
function GetHeldItem(values)
{
    const stmt = `SELECT * FROM HeldItem WHERE heldid = ?`;
    return pool.query(stmt, values);
}

//Route 7
function GetAllBoostEmblems()
{
    const stmt = `SELECT emblemid, sprite, name FROM BoostEmblem`;
    return pool.query(stmt);
}

function GetBoostEmblem(values)
{
    const stmt = `SELECT * FROM BoostEmblem WHERE name = ?`;
    return pool.query(stmt, values);
}

//Route 8
function GetFilteredBoostEmblems(values)
{
    filterParams = [];

    let colorstmt = '';
    if(values[0] != 'NULL')
    {
        colorstmt = `WHERE E2.color1 = ? OR E2.Color2 = ?`;
        filterParams.push(values[0]);
        filterParams.push(values[0]);
    }

    let attribstmt = '';
    if(values[1] != 'NULL')
    {
        attribstmt = `WHERE E3.Attrib1Type = ? OR E3.Attrib2Type = ?`;
        filterParams.push(values[1]);
        filterParams.push(values[1]);
    }

    const basestmt = `SELECT E1.emblemid, E1.sprite, E1.name FROM BoostEmblem E1 WHERE 
                        E1.emblemid IN (SELECT E2.emblemid FROM BoostEmblem E2 ${colorstmt}) AND
                        E1.emblemid IN (SELECT E3.emblemid FROM BoostEmblem E3 ${attribstmt})`;
    console.log("sent query: " + basestmt);
    return pool.query(basestmt, filterParams);
}

//Route 8
function GetFilteredBoostEmblemsCount(values)
{
    filterParams = [];

    let colorstmt = '';
    if(values[0] != 'NULL')
    {
        colorstmt = `WHERE E2.color1 = ? OR E2.Color2 = ?`;
        filterParams.push(values[0]);
        filterParams.push(values[0]);
    }

    let attribstmt = '';
    if(values[1] != 'NULL')
    {
        attribstmt = `WHERE E3.Attrib1Type = ? OR E3.Attrib2Type = ?`;
        filterParams.push(values[1]);
        filterParams.push(values[1]);
    }

    const basestmt = `SELECT COUNT (E1.emblemid) FROM BoostEmblem E1 WHERE 
                        E1.emblemid IN (SELECT E2.emblemid FROM BoostEmblem E2 ${colorstmt}) AND
                        E1.emblemid IN (SELECT E3.emblemid FROM BoostEmblem E3 ${attribstmt})`;
    console.log("sent query: " + basestmt);
    return pool.query(basestmt, filterParams);
}

//Route 9
function GetAllEmblemLoadouts()
{
    const stmt = `SELECT * FROM EmblemLoadout L1 LEFT JOIN EmblemSlot S1 ON L1.loadoutid = S1.loadoutid`;
    console.log("sent query: " + stmt);
    return pool.query(stmt);
}
//Route 9
function GetEmblemLoadout(values)
{
    const stmt = `SELECT * FROM EmblemLoadout L1 LEFT JOIN EmblemSlot S1 ON L1.loadoutid = S1.loadoutid WHERE loadoutid = ?`;
    console.log("sent query: " + stmt);
    return pool.query(stmt, values);
}
//Route 9
function CreateEmblemLoadout(values)
{
    const stmt = `INSERT INTO EmblemLoadout(name) VALUES (?)`;
    console.log("sent query: " + stmt);
    return pool.query(stmt, values)
    .then(result => { 
        return result[0].insertId;
    });
}
//Route 9
function InsertIntoLoadout(loadoutId, emblemIds)
{
    const values = [
        [loadoutId, emblemIds[0]],
        [loadoutId, emblemIds[1]],
        [loadoutId, emblemIds[2]],
        [loadoutId, emblemIds[3]],
        [loadoutId, emblemIds[4]],
        [loadoutId, emblemIds[5]],
        [loadoutId, emblemIds[6]],
        [loadoutId, emblemIds[7]],
        [loadoutId, emblemIds[8]],
        [loadoutId, emblemIds[9]]
    ];
    const stmt = `INSERT INTO EmblemSlot(loadoutid, emblemid) VALUES ?`;
    console.log(stmt);
    return pool.query(stmt, [values]);
}

//Route 9
function UpdateEmblemLoadout(values)
{
    if(values["name"])
    {
        let stmt = `UPDATE EmblemLoadout SET name = ? WHERE loadoutid = ?`;
        console.log(stmt, values);
        return pool.query(stmt, [values["name"], values ["loadoutid"]]);
    }
}

//Route 9
function DeleteEmblemLoadout(values)
{
    const stmt = `DELETE FROM EmblemLoadout WHERE loadoutid = ?`;
    return pool.query(stmt, values);
}

function GetBuilds(values)
{
    const stmt = `SELECT * FROM PokemonBuild WHERE ownerid = ?`;
    return pool.query(stmt, values, callback);
}

function CreateBuild(values)
{
    const stmt = `INSERT INTO PokemonBuild(ownerid, name, move1, move2, helditemid1, helditemid2, helditemid3, battleitemid, loadoutid) VALUES ROW (?, ?, ?, ?, ?, ?, ?, ?, ?)`;
    return pool.query(stmt, values);
}

function DeleteBuild(values)
{
    const stmt = `DELETE FROM PokemonBuild WHERE buildid = ?`;
    return pool.query(stmt, values);
}

function UpdateBuild(values)
{
    let stmt = `UPDATE PokemonBuild SET`;
    updated = [];

    for(let key in values)
    {
        if(values[key] && key != "buildid")
        {
            updated.push(`${key} = ${pool.escape(values[key])}`);
        }
    }

    stmt += " " + updated.join(", ") + " WHERE buildid = ?";
    return pool.query(stmt, values["buildid"]);
}

module.exports = 
{
    //Route 1
    AllPokemon: GetAllPokemon,
    //Route 2
    FilteredPokemon: GetFilteredPokemon,
    FilteredCountPokemon:  GetFilteredPokemonCount,
    //Route 3
    OnePokemon_Pokemon: GetPokemon,
    OnePokemon_Stats: GetStats,
    OnePokemon_Skills: GetSkills,
    //Route 4
    AllBattle: GetAllBattleItems,
    AllHeld: GetAllHeldItems,
    //Route 5
    OneBattle: GetBattleItem,
    //Route 6
    OneHeld: GetHeldItem,
    //Route 7
    AllEmblems: GetAllBoostEmblems,
    OneEmblem: GetBoostEmblem,
    //Route 8
    FilteredEmblems: GetFilteredBoostEmblems,
    FilteredCountEmblems: GetFilteredBoostEmblemsCount,
    //Route 9
    AllLoadout: GetAllEmblemLoadouts,
    OneLoadout: GetEmblemLoadout,
    CreateLoadout: CreateEmblemLoadout,
    InsertEmblem: InsertIntoLoadout,
    UpdateLoadout: UpdateEmblemLoadout,
    DeleteLoadout: DeleteEmblemLoadout,
    //Route 10
    GetBuilds,
    CreateBuild,
    DeleteBuild,
    UpdateBuild
}