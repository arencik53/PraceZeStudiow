function losujLiczby() {
  const liczby = new Set();
  while (liczby.size < 6) {
    liczby.add(Math.floor(Math.random() * 49) + 1);
  }
  return Array.from(liczby).sort((a, b) => a - b);
}

function sprawdzPoprawnosc(liczby) {
  if (liczby.length !== 6) return false;
  const unikalne = new Set(liczby);
  if (unikalne.size !== 6) return false;
  return liczby.every(n => n >= 1 && n <= 49);
}

document.getElementById("formularzLotto").addEventListener("submit", (e) => {
  e.preventDefault();

  const inputs = e.target.querySelectorAll("input[type='number']");
  const liczbyUzytkownika = Array.from(inputs).map(i => Number(i.value));

  const wynikDiv = document.getElementById("wynik");
  wynikDiv.innerHTML = "";

  if (!sprawdzPoprawnosc(liczbyUzytkownika)) {
    wynikDiv.innerHTML = "<p style='color:red;'>Wprowadź 6 różnych liczb z zakresu 1–49!</p>";
    return;
  }

  const wylosowane = losujLiczby();

  const trafione = liczbyUzytkownika.filter(n => wylosowane.includes(n));
  const liczbaTrafien = trafione.length;

  let nagroda = "";
  switch (liczbaTrafien) {
    case 6: nagroda = "Główna wygrana!"; break;
    case 5: nagroda = "Gratulacje! Trafiłeś piątkę!"; break;
    case 4: nagroda = "Trafiłeś czwórkę!"; break;
    case 3: nagroda = "Trafiłeś trójkę!"; break;
    default: nagroda = "Brak wygranej, spróbuj ponownie.";
  }

  wynikDiv.innerHTML = `
    <p><strong>Twoje liczby:</strong> ${liczbyUzytkownika.sort((a,b)=>a-b).join(", ")}</p>
    <p><strong>Wylosowane liczby:</strong> ${wylosowane.join(", ")}</p>
    <p><strong>Trafione:</strong> ${trafione.join(", ") || "brak"}</p>
    <p><strong>Wynik:</strong> ${nagroda}</p>
  `;

document.getElementById("losujBtn").addEventListener("click", () => {
  const inputs = document.querySelectorAll("#formularzLotto input[type='number']");
  
  const wylosowane = losujLiczby();

  inputs.forEach((input, index) => {
    input.value = wylosowane[index];
  });
});
});