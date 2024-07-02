import { Route, Routes } from "react-router-dom";
import { ThemeProvider, createTheme } from "@mui/material";

import Home from "./Home.jsx";
import FirstPage from "../Pages/FirstPage.jsx"; //ilk nokta src demektir ama ikinci nokta belli klasörun içi demektir.
import SignIn from "../Pages/Customer Sayfaları/Signin.jsx";
import SignUp from "../Pages/Customer Sayfaları/Signup.jsx";
import Dashboard from "../Pages/Admin Sayfaları/Dashboard.jsx";
import Orders from "../Pages/Admin Sayfaları/Orders.jsx";
import AdminLogin from "./Admin Sayfaları/AdminLogin.jsx";

//Sayfalar arası gezinti olayı buradan kontrol edilecektir.

const theme = createTheme();

function App() {
  return (
    <ThemeProvider theme={theme}>
      <Routes>
        {/* Burada her sayfa hangi adresten gideceğini söyluyor */}

        {/* Müşteri Sayfaları: */}
        <Route exact path="/" element={<Home />}></Route>  {/* giriş sayfasına gideceği link (uri) */}
        <Route exact path="/firstpage" element={<FirstPage />}></Route>  
        <Route exact path="/signin" element={<SignIn />}></Route>        
        <Route exact path="/signup" element={<SignUp />}></Route>

        {/* Admin sayfaları: */}
        <Route exact path="/admin/dashboard" element={<Dashboard />}></Route>
        <Route exact path="/admin/orders" element={<Orders />}></Route>
        <Route exact path="/admin/login" element={<AdminLogin />}></Route>  
      </Routes>
    </ThemeProvider>
  );
}
export default App;
