
fetch("https://localhost:3002/api/Client")
    .then( response => response.json())
    .then(data => console.log(data))