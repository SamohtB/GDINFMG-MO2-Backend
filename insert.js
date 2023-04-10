const {PythonShell} = require("python-shell");
const mysql = require('mysql2');
require("dotenv").config();

let shell = new PythonShell('populate/unite.py');

const pool = mysql.createConnection({
  host: process.env.SQL_HOST,
  user: 'root',
  password: process.env.SQL_PASSWORD,
  database: process.env.SQL_DB
});

PythonShell.run('populate/unite.py').then(messages=>{
  console.log(messages);

  pool.connect(function(err) {  

    if (err) throw err;  
    console.log("Connected!");  
    var sql = "INSERT INTO Pokemon(name, attacktype, attackstyle, role, complexity) VALUES ?";  
    var values = messages;

    pool.query(sql, [values], function (err, result) {  
      if (err) throw err;  
      console.log("Number of records inserted: " + result.affectedRows);  
    });  
    });  
});