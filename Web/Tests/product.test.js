
const { test, expect } = require("@jest/globals");
const { getPokemon } = require("./mockFunctions");

beforeAll(() => {
    require("whatwg-fetch");
  });
  
  describe("Locations API", () => {
    test("it returns a list of locations", async () => {
      const expected = [
        { name: "ivysaur"},
        { name: "venusaur"},
        { name: "charmander"},
        { name: "bulbasaur"}
      ];

      jest.spyOn(window, "fetch").mockImplementation(() => {
        const fetchResponse = {
          ok: true,
          json: () => Promise.resolve(expected)
        };
        return Promise.resolve(fetchResponse);
      });
  
      const json = await getPokemon();
      expect(json).toMatchObject(expected);
    });
  });


// test("Gets list of books for selected location", () => {
//   expect();
// });
