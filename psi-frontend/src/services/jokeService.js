import http from "./httpService";
import auth from "./authService";

const apiEndpoint = "https://joke3.p.rapidapi.com/v1/joke";



export function getJoke() {
    
   const joke = fetch("https://joke3.p.rapidapi.com/v1/joke", {
	"method": "GET",
	"headers": {
		"x-rapidapi-key": "6b37d15661mshedc7c8e5818e3b6p112339jsn318e3588c024",
		"x-rapidapi-host": "joke3.p.rapidapi.com"
	}
})
.then(response => response.json());
    console.log(joke);
  return joke;

}
