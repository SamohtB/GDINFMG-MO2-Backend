const express = require("express");
const db = require("../db/db.js");
const bodyParser = require("body-parser");
const router = express.Router();

router.use(bodyParser.json());

//all pokemon names
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

//filtered pokemon
router.get("/pokemon/:AttackType.:AttackStyle.:Role.:Complexity", (req, res) => 
{
    values = [req.params.AttackType, req.params.AttackStyle, req.params.Role, req.params.Complexity];
    const pokemon = db.FilteredPokemon(values, function(err, results, fields)
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

//single pokemon with stats at level 
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

//single pokemon with stats
router.get("/pokemon/:PokemonId", (req, res) => 
{
    values = [req.params.PokemonId];
    const pokemon = db.OnePokemonAllStats(values, function(err, results, fields)
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