const express = require("express");
const db = require("../db/db.js");
const router = express.Router();

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

router.get("/pokemon/:PokemonId-:level", (req, res) => 
{
    values = [req.params.PokemonId, req.params.level];
    const pokemon = db.OnePokemon(values, function(err, results, fields)
    {
        if(err)
        {
            console.error("An error occured: ", err);
            return res.status(500).send("Error fetching Pokemon");
        }

        console.log("get one pokemon query successful: ", results);
        res.json(results);
    })
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

module.exports = router;