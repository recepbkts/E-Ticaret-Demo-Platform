import { useState } from "react";
import reactLogo from "../assets/react.svg"; //    ./ --> yani src(Source kaynak demektir) klasöru
import viteLogo from "/vite.svg"; //   /  --> public klasörunu hedefliyor.
import "../Themes/FirstPage.css";
import Button from "@mui/material/Button/Button";
import { Link, useNavigate } from "react-router-dom";
import HomeIcon from "@mui/icons-material/Home";
import LoginIcon from "@mui/icons-material/Login";
import SignUpIcon from "@mui/icons-material/VpnKey";

//Fonksiyon ile component(Bileşen) yazıyoruz ve onu tag gibi başka yerde kullanıyoruz.

export default function FirstPage() {
  //App fonksiyonu varsayılan olarak tanı.
  
  const [sayi, setSayi] = useState(0); //C# daki gibi,burada sayi --> GET ve setSayi --> SET demektir. useState yani varsayılan durumu ilk olarak 0 olsun. yani varsayılan değeri sayi=0 .

  const navigate = useNavigate();

  return (
    //her fonksiyonun bir döndürdüğü değerı vardır.
    //Başlangıç için bir tag içinde kullanmak zorunlu.
    <div className="firstPage">
      <div>
        <a href="https://vitejs.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>Vite + React</h1>
      <div className="card">
        <button onClick={() => setSayi((sayi) => sayi + 1)}>
          sayi is {sayi}
        </button>
        <br />
        <br />
        <Button onClick={() => navigate("/")}>
          <HomeIcon sx={{ fontSize: 70, color: "#e90de8" }} />
        </Button>
        <br />
        <br />

        <Link to={"/signin"}>
          {" "}
          <Button variant="contained">
            <LoginIcon
              sx={{ paddingTop: "5px", color: "#fff", width: "80px" }}
            />
          </Button>
        </Link>

        <br />
        <br />

        <Link to={"/signup"}>
          {" "}
          <Button color="success" variant="contained" sx={{ width: "150px" }}>
            <SignUpIcon sx={{ paddingTop: "5px", color: "white" }} />
          </Button>
        </Link>

        <p>
          Edit <code>src/App.jsx</code> and save to test HMR
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
    </div>
  );
}
