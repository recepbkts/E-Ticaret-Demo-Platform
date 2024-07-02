import React from "react";
import ReactDOM from "react-dom/client";
//import "./index.css";
import App from "./Pages/App.jsx";
import { BrowserRouter as Router } from "react-router-dom";

//React de her zaman projeniz bu sayfadan başlar. yani main.jsx c# daki Program.cs gibi ana sayfanızdir.


ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <Router>  {/* Router sayfaları çağırmak için kullanılır */}
      <App />
    </Router>
  </React.StrictMode>
);
