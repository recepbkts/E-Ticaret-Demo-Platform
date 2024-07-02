import { CCarousel, CCarouselItem, CImage } from "@coreui/react";
import { useEffect, useState } from "react";
import Image1 from "../assets/1.jpg";
import Image2 from "../assets/2.jpg";
import Image3 from "../assets/3.jpg";
import Image4 from "../assets/4.jpg";
import "@coreui/coreui/dist/css/coreui.min.css";
import ResponsiveAppBar from "../Components/ResponsiveAppBar";
import { Grid } from "@mui/material";
import MediaCard from "../Components/MediaCard";
import Footer from "../Components/Footer";

//npm install @coreui/react @coreui/coreui

export default function Home() {
  const [products, setProducts] = useState([]);

  const [windowWidth, setWindowWidth] = useState(window.innerWidth);

  const carouselMarginTop = windowWidth <= 1300 ? "5.8vh" : "6.7vh";

  useEffect(() => {
    fetch("https://dummyjson.com/products", {
      method: "GET",
      mode: "cors",
      cache: "no-cache",
      headers: {
        "content-Type": "application/json",
      },
    }).then(async (response) => {
      if (response.status === 200) {
        let result = await response.text().then((text) => {
          return text ? JSON.parse(text) : null;
        });
        setProducts(result.products);
      }
    });

    const handleResize = () => setWindowWidth(window.innerWidth);
    window.addEventListener("resize", handleResize);
    return () => window.removeEventListener("resize", handleResize);
  }, []);

  return (
    <>
      <ResponsiveAppBar />
      <CCarousel
        dark
        pause={"hover"}
        interval={2000} //2 saniye geciktirme
        style={{ marginTop: carouselMarginTop }}
        controls
        indicators
      >
        <CCarouselItem>
          <CImage className="d-block w-100" src={Image1} alt="slide 1" />
        </CCarouselItem>
        <CCarouselItem>
          <CImage className="d-block w-100" src={Image2} alt="slide 2" />
        </CCarouselItem>
        <CCarouselItem>
          <CImage className="d-block w-100" src={Image3} alt="slide 3" />
        </CCarouselItem>
        <CCarouselItem>
          <CImage className="d-block w-100" src={Image4} alt="slide 4" />
        </CCarouselItem>
      </CCarousel>
      <Grid container spacing={2} sx={{ p: 5, backgroundColor: "#f09b99" }}>
        {products.map((product) => (
          <Grid item lg={3} md={4} sm={6} xs={12} key={product.id}>
            <MediaCard
              title={product.title}
              description={product.description}
              image={product.thumbnail}
              price={product.price}
            />
          </Grid>
        ))}
      </Grid>
      <Footer/>
    </>
  );
}
