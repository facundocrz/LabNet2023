let highscore = localStorage.getItem("highscore") || 0;

document.querySelector("#highscore").innerHTML = highscore;

let number;
let rounds = [];

document.querySelector("#guessForm").addEventListener("submit", (e) => {
  e.preventDefault();
  let guess = document.querySelector("#guess").value;

  if (guess < 1 || guess > 100 || isNaN(guess)) {
    document.querySelector("#result").innerHTML =
      "Por favor ingresa un número entre 1 y 100";
    return;
  }

  attempts--;
  score -= 10;
  document.querySelector("#score").innerHTML = score;
  document.querySelector(
    "#attempts"
  ).innerHTML = `Adiviná el número entre 1 y 100, tenés ${attempts} intentos`;

  if (Number(guess) === number) {
    document.querySelector("#result").innerHTML =
      "Felicitaciones! adivinaste el número";
    document.querySelector("#guessButton").classList.add("hidden");
    if (score > highscore) {
      localStorage.setItem("highscore", score);
      document.querySelector("#highscore").innerHTML = score;
    }
    document.querySelector("body").classList.add("win");
    rounds.push({ attempts: 10 - attempts, score: score, number: guess });
    updateRounds();
  } else if (attempts === 0) {
    document.querySelector(
      "#result"
    ).innerHTML = `Perdiste! no te quedan más intentos, el número era ${number}`;
    document.querySelector("body").classList.add("lose");
    rounds.push({ attempts: 10, score: 0, number: number });
    updateRounds();
    document.querySelector("#guessButton").classList.add("hidden");
  } else if (Number(guess) > number) {
    document.querySelector("#result").innerHTML = "El número es menor";
  } else if (Number(guess) < number) {
    document.querySelector("#result").innerHTML = "El número es mayor";
  }
});

const updateRounds = () => {
  let rowHTML = `<td>${rounds[rounds.length-1].number}</td><td>${rounds[rounds.length-1].attempts}</td><td>${rounds[rounds.length-1].score}</td>`;
  let row = document.createElement("tr");
  row.innerHTML = rowHTML;
  document.querySelector("#roundsTable tbody").appendChild(row);
};


const iniciarJuego = () => {
  number = Math.round(Math.random() * 100 + 1);
  attempts = 10;
  score = 100;
  document.querySelector(
    "#attempts"
  ).innerHTML = `Adiviná el número entre 1 y 100, tenés ${attempts} intentos`;
  document.querySelector("#guess").value = "";
  document.querySelector("#score").innerHTML = score;
  document.querySelector("#result").innerHTML = "";
  document.querySelector("#guessButton").classList.remove("hidden");
  document.querySelector("body").classList.remove("win");
  document.querySelector("body").classList.remove("lose");
};

document.querySelector("#restart").addEventListener("click", iniciarJuego);

iniciarJuego();
