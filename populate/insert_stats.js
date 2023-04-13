const {PythonShell} = require("python-shell");
const mysql = require('mysql2');
const { options } = require("../src/routes/routes");
require("dotenv").config();

let shell = new PythonShell('populate/unite_pokemon_stats.py');

const pool = mysql.createConnection({
  host: process.env.SQL_HOST,
  user: 'root',
  password: process.env.SQL_PASSWORD,
  database: process.env.SQL_DB
});

options.JSON;

shell.on('message', function(message){

  pool.connect(function(err) {  

    if (err) throw err;   
    sql = "INSERT INTO Stats(ownerid, level, HP, ATK, DEF, SpA, SpD, criticalrate, cooldownredux, lifesteal) VALUES ROW (?)";
    message = JSON.parse(message);
    values = [message["ownerid"], message["level"], message["HP"], message["ATK"], message["DEF"], message["SpA"], message["SpD"], 
              message["criticalrate"], message["cooldownredux"], message["lifesteal"]];
    pool.query(sql, [values], function (err, result) {
      if(err)
      {
          console.log("An error occured");
          console.error(err);
          return;
      }
      console.log(result);
    });  
    });  
});

shell.end(function (err,code,signal) {
  if (err) throw err;
  console.log('The exit code was: ' + code);
  console.log('The exit signal was: ' + signal);
  console.log('finished');
});