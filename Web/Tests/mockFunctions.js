// const ENDPOINT = "https://pokeapi.co/api/v2/pokemon/";

const ENDPOINT = "https://api.valentinog.com/api/users/";

// EXAMPLE:
// function getUsers() {
//   return fetch(ENDPOINT)
//     .then((response) => {
//       if (!response.ok) throw Error(response.statusText);
//       return response.json();
//     })
//     .then((json) => json);
// }

// module.exports = { getUsers };

function getPokemon() {
  return fetch(ENDPOINT)
    .then((response) => {
      if (!response.ok) throw Error(response.statusText);
      return response.json();
    })
    .then((json) => json);
}
module.exports = { getPokemon };
