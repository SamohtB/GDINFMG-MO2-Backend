const mysql = require('mysql2/promise');
require("dotenv").config();

const pool = mysql.createPool({
    host: process.env.SQL_HOST,
    user: 'root',
    password: process.env.SQL_PASSWORD,
    database: process.env.SQL_DB,
});

//Route 1 - All Pokemon
function GetAllPokemon(callback) 
{
    const stmt = `SELECT pokemonid, sprite, name FROM Pokemon`;
    pool.query(stmt, callback);
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
    return pool.query(basestmt, filterParams);
}

//Route 3 - Specific Pokemon With Stats and Skills
function GetPokemon(values)
{
    const stmt = `SELECT * FROM Pokemon WHERE pokemonid = ?`;
    return pool.query(stmt, values);
}
//Route 3
function GetSkills(values)
{
    const stmt = `SELECT * FROM Skill WHERE ownerid = ?`;
    return pool.query(stmt, values);
}
//Route 3
function GetStats(values)
{
    const stmt = `SELECT * FROM Stats WHERE ownerid = ?`;
    return pool.query(stmt, values);
}

function GetAllBattleItems(callback)
{
    //Add sprite later
    const stmt = `SELECT battleid, name FROM BattleItem`;
    pool.query(stmt, callback);
}

function GetBattleItem(id, callback)
{
    const stmt = `SELECT * FROM BattleItem WHERE battleid = ?`;
    pool.query(stmt, id, callback);
}

function GetAllHeldItems(callback)
{
    //Add sprite later
    const stmt = `SELECT heldid, name FROM HeldItem`;
    pool.query(stmt, callback);
}

function GetHeldItem(values, callback)
{
    const stmt = `SELECT * FROM HeldItem WHERE heldid = ?`;
    pool.query(stmt, values, callback);
}

function GetBuilds(values, callback)
{
    const stmt = `SELECT * FROM PokemonBuild WHERE ownerid = ?`;
    pool.query(stmt, values, callback);
}

function CreateBuild(values, callback)
{
    const stmt = `INSERT INTO PokemonBuild(ownerid, name, move1, move2, helditemid1, helditemid2, helditemid3, battleitemid) VALUES ROW (?, ?, ?, ?, ?, ?, ?, ?)`;
    pool.query(stmt, values, callback);
}

function DeleteBuild(values, callback)
{
    const stmt = `DELETE FROM PokemonBuild WHERE buildid = ?`;
    pool.query(stmt, values, callback);
}

function UpdateBuild(values, callback)
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
    pool.query(stmt, values["buildid"], callback);
}

module.exports = 
{
    //Route 1
    AllPokemon: GetAllPokemon,
    //Route 2
    FilteredPokemon: GetFilteredPokemon,
    FilteredCount:  GetFilteredPokemonCount,
    //Route 3
    OnePokemon_Pokemon: GetPokemon,
    OnePokemon_Stats: GetStats,
    OnePokemon_Skills: GetSkills,
    //Route 4
    AllBattle: GetAllBattleItems,
    OneBattle: GetBattleItem,
    AllHeld: GetAllHeldItems,
    OneHeld: GetHeldItem,
    Builds: GetBuilds,
    CreateBuild,
    DeleteBuild,
    UpdateBuild
}