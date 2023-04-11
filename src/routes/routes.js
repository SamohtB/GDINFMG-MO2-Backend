const express = require("express");
const db = require("../db/db.js");
const router = express.Router();

router.get("/pokemon", (req, res) => 
{
    const pokemon = db.AllPokemon(function(err, results)
    {
        if(err)
        {
            console.log("An error occured");
            console.error(err);
            res.sendStatus(500);
            return;
        }

        console.log("get all pokemon query successful");
        res.json(results);
    });
});

router.get("/pokemon/:PokemonId", (req, res) => 
{
    const pokemon = db.OnePokemon(req.params.PokemonId, function(err, results)
    {
        if(err)
        {
            console.log("An error occured");
            console.error(err);
            res.sendStatus(500);
            return;
        }
        console.log(req.params.PokemonId + " received");
        res.json(results);
    })
});


module.exports = router;