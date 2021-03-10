<?php
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Headers: access");
header("Access-Control-Allow-Methods: GET");
header("Access-Control-Allow-Credentials: true");
header("Content-Type: application/json");

//We thank DontMissTheFlight for the making of this script
include( "../includes/db_connect.php" );

//variables from the user/program/game


//Connections

$conn = sqlsrv_connect( $serverName, $connectionInfo);

//Test connection

if($conn->connect_error)
{
  // set response code - 404 Not found
  http_response_code(404);

  die("Connection failed: " . $conn->connect_error);// Kill it if there is an error...dont keep running the code
}

//SQL Command
$sql = "SELECT TOP 10 Initials, Score FROM PnSHigh ORDER BY Score DESC";
$result = sqlsrv_query ( $conn, $sql);
if($result == false)
{
  // set response code - 404 Not found
  http_response_code(404);

  die("Query invalid");
}
// Array to store everything from result
$ScoreArray = [];
while($row = sqlsrv_fetch_object($result))
{
	array_push($ScoreArray,$row);
}

// set response code - 200 OK
http_response_code(200);

//Real Return 

echo json_encode($ScoreArray);


$conn->close(); // closes connection

?>