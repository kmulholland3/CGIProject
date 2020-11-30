
function getRests(){
    const allRestsApiUrl = "https://localhost:5001/api/restaurant";

    fetch(allRestsApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let count = 1;
        let html = "<ul>";
        json.forEach((restaurant)=>{
            html += "<li>" + count + ". " + restaurant.name + "</li>" 
            + "<button onclick=\"deleteRest("+restaurant.id+")\">Delete</button>";
            count++;
        });
        html += "</ul>";
        document.getElementById("restaurants").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}
function postRest(){
    const postRestApiUrl = "https://localhost:5001/api/restaurant";
    const RestName = document.getElementById("RestaurantOptions").value;
    console.log(RestName);

    fetch(postRestApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            name: RestName
        })
    })
    .then((response)=>{
        console.log(response);
        getRests();
    })
}

deleteRest= function(id){
    console.log(id);
    const deleteRestApiUrl = "https://localhost:5001/api/restaurant/" + id;

    fetch(deleteRestApiUrl, {
        method: "DELETE",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        }
    })
    .then((response)=>{
        console.log(response);
        getRests();
    })
}