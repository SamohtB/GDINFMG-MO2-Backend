const express = require("express");
const db = require("../db/db.js");
const bodyParser = require("body-parser");
const mysql = require('mysql2/promise');
const router = express.Router();

router.use(bodyParser.json());

//1 Get All Pokemon Sprites - For main pokemon list
router.get("/pokemon", (req, res) => {
    const pokemon = db.AllPokemon(function(err, results, fields) 
    {
        if(err)
        {
            console.error("An error occured: ", err);
            return res.status(500).send("Error fetching Pokemon");
        }

        console.log("get all pokemon query successful: ", results);
        res.json(results);
    });
});

//2 Get Filtered Pokemon and Count- When Filter is Called
router.get("/pokemon/:AttackType.:AttackStyle.:Role.:Complexity", (req, res) => 
{
    const filterValues = [req.params.AttackType, req.params.AttackStyle, req.params.Role, req.params.Complexity];
    const promises = [
        db.FilteredPokemon(filterValues),
        db.FilteredCount(filterValues)
    ];

    Promise.all(promises)
        .then((results) => {
            const pokemon = results[0][0];
            const count = results[1]
            const response = {
                pokemon : pokemon,
                count : count
            };
        
        console.log(response);
        res.json(response);

        })
        .catch((error) => {
            console.error("An error occured: ", error);
            return res.status(500).send("Error fetching filtered Pokemon");
        });
});

//3 Get Specific Pokemon with stats and skills
router.get("/pokemon/:PokemonId", (req, res) => 
{
    const pokemonID = [req.params.PokemonId];
    const promises = [
        db.OnePokemon_Pokemon(pokemonID),
        db.OnePokemon_Stats(pokemonID),
        db.OnePokemon_Skills(pokemonID)
    ];

    Promise.all(promises)
        .then((results) => {
            const pokemon = results[0][0];
            const stats = results[1];
            const skills = results[2];
            const response = {
                pokemon : pokemon,
                stats : stats,
                skills : skills
            };

            console.log(response);
            res.json(response);
        })
        .catch((error) => {
            console.error("An error occured: ", error);
            return res.status(500).send("Error fetching Pokemon");
        });
});

router.get("/BattleItem", (req, res) => 
{
    const item = db.AllBattle(function(err, results, fields)
    {
        if(err)
        {
            console.error("An error occured: ", err);
            return res.status(500).send("Error fetching Battle Items");
        }

        console.log("get all battle items query successful: ", results);
        res.json(results);
    });
})

router.get("/BattleItem/:BattleId", (req, res) =>
{
    values = [req.params.BattleId];
    const pokemon = db.OneBattle(values, function(err, results, fields)
    {
        if(err)
        {
            console.error("An error occured: ", err);
            return res.status(500).send("Error fetching battle item");
        }

        console.log("get one battle query successful: ", results);
        res.json(results);
    })
});

router.get("/HeldItem",(req, res) =>
{
    const item = db.AllHeld(function(err, results, fields)
    {
        if(err)
        {
            console.error("An error occured: ", err);
            return res.status(500).send("Error fetching Held Items");
        }

        console.log("get all held items query successful: ", results);
        res.json(results);
    });
});

router.get("/HeldItem/:HeldId", (req, res) =>
{
    values = [req.params.HeldId];
    const pokemon = db.OneBattle(values, function(err, results, fields)
    {
        if(err)
        {
            console.error("An error occured: ", err);
            return res.status(500).send("Error fetching held item");
        }

        console.log("get one held query successful: ", results);
        res.json(results);
    })
});

router.get("/Build/:PokemonId", (req, res) =>
{
    values = [req.params.PokemonId];
    const pokemon = db.Builds(values, function(err, results, fields)
    {
        if(err)
        {
            console.error("An error occured: ", err);
            return res.status(500).send("Error fetching pokemon builds");
        }

        console.log("get all builds query successful: ", results);
        res.json(results);
    })
});

router.post("/Build", (req, res) =>
{
    values = [
        req.body.ownerid, 
        req.body.name, 
        req.body.move1, 
        req.body.move2, 
        req.body.helditem1id, 
        req.body.helditem2id, 
        req.body.helditem3id, 
        req.body.battleitemid
    ];

    console.log(values);
    const pokemon = db.CreateBuild(values, function(err, results, fields)
    {
        if(err)
        {
            console.error("An error occured: ", err);
            return res.status(500).send("Error posting pokemon builds");
        }

        console.log("post build successful: ", results);
    })
});

router.put("/Build", (req, res) =>
{
    const values = {
        buildid: req.body.buildid,
        ownerid: req.body.ownerid,
        name: req.body.name,
        move1: req.body.move1,
        move2: req.body.move2,
        helditem1id: req.body.helditem1id,
        helditem2id: req.body.helditem2id,
        helditem3id: req.body.helditem3id,
        battleitemid: req.body.battleitemid
    };

    console.log(values);
    const pokemon = db.UpdateBuild(values, function(err, results, fields)
    {
        if (err)
        {
            {
                console.error("An error occured: ", err);
                return res.status(500).send("Error updating pokemon builds");
            }
        }
        console.log("Number of records updated: " + results.affectedRows);
    })
});

router.delete("/Build", (req, res) =>
{
    values = [req.body.buildid];
    console.log(values);
    const pokemon = db.DeleteBuild(values, function(err, results, fields)
    {
        if (err)
        {
            {
                console.error("An error occured: ", err);
                return res.status(500).send("Error deleting pokemon builds");
            }
        }
        console.log("Number of records deleted: " + results.affectedRows);
    })
});


module.exports = router;