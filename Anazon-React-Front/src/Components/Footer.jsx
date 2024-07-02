import { Box, Grid, Typography } from "@mui/material";
import Copyright from "./Copyright";
import appStoreLogo from "../assets/app-store.png"
import playStoreLogo from "../assets/play-store.png"

export default function Footer() {
  return (
    <Box
      sx={{ backgroundColor: "#989595", pt: 5, pb: 1, pl: 10, pr: 10 }}
      component="footer"
    >
      <Grid container spacing={5}>
        <Grid item lg={2} sm={6} xs={12} key={4}>
          <Typography
            component="h6"
            variant="h6"
            color="orange"
            noWrap
            sx={{ flexGrow: 1, fontWeight: "bold" }}
          >
            About Us
          </Typography>
          <Grid container rowSpacing={1} direction="column">
            <Grid item>
              Lorem Ipsum is simply dummy text of the printing and typesetting
              industry. Lorem Ipsum has been the industry's standard dummy text
              ever since the 1500s, when an unknown printer took a galley of
              type and scrambled it to make a type specimen book. 
            </Grid>
          </Grid>
        </Grid>
        <Grid item lg={2} sm={6} xs={12} key={4}>
          <Typography
            component="h6"
            variant="h6"
            color="orange"
            noWrap
            sx={{ flexGrow: 1, fontWeight: "bold" }}
          >
            Other Links
          </Typography>
          <Grid container rowSpacing={1} direction="column" color={"white"}>
            <Grid item component={"li"}>
              <a
                href="/admin/login"
                target="_blank"
                style={{ textDecoration: "none", color: "white" }}
              >
                Admin Login
              </a>
            </Grid>
            <Grid item component={"li"}>
              <a
                href="https://www.google.com/"
                target="_blank"
                style={{ textDecoration: "none", color: "white" }}
              >
                Hendreit
              </a>
            </Grid>
            <Grid item component={"li"}>
              <a
                href="https://www.google.com/"
                target="_blank"
                style={{ textDecoration: "none", color: "white" }}
              >
                Dolar
              </a>
            </Grid>
            <Grid item component={"li"}>
              <a
                href="https://www.google.com/"
                target="_blank"
                style={{ textDecoration: "none", color: "white" }}
              >
                Sit
              </a>
            </Grid>
            <Grid item component={"li"}>
              <a
                href="https://www.google.com/"
                target="_blank"
                style={{ textDecoration: "none", color: "white" }}
              >
                Amet
              </a>
            </Grid>
            <Grid item component={"li"}>
              <a
                href="https://www.google.com/"
                target="_blank"
                style={{ textDecoration: "none", color: "white" }}
              >
                Labore
              </a>
            </Grid>
            <Grid item component={"li"}>
              <a
                href="https://www.google.com/"
                target="_blank"
                style={{ textDecoration: "none", color: "white" }}
              >
                Alique
              </a>
            </Grid>
          </Grid>
        </Grid>
        <Grid item lg={2} sm={6} xs={12} key={4}>
        <Typography
            component="h6"
            variant="h6"
            color="orange"
            noWrap
            sx={{ flexGrow: 1, fontWeight: "bold" }}
          >
            Social Network
          </Typography>
          <Grid container rowSpacing={1} direction={"column"}>
            <Grid item >
                <img src={appStoreLogo} style={{maxWidth:"35%"}}/>
            </Grid>
            <Grid item >
                <img src={playStoreLogo} style={{maxWidth:"35%"}}/>
            </Grid>
          </Grid>
        </Grid>
        <Grid item lg={3} sm={6} xs={12} key={4}>
        <Typography
            component="h6"
            variant="h6"
            color="orange"
            noWrap
            sx={{ flexGrow: 1, fontWeight: "bold" }}
          >
            Mobile App Download
          </Typography>
          <Grid container rowSpacing={1} direction={"column"}>
            <Grid item >
                <img src={appStoreLogo} style={{maxWidth:"35%"}}/>
            </Grid>
            <Grid item >
                <img src={playStoreLogo} style={{maxWidth:"35%"}}/>
            </Grid>
          </Grid>
        </Grid>
        <Grid item lg={3} sm={6} xs={12} key={4}>
        <Typography
            component="h6"
            variant="h6"
            color="orange"
            noWrap
            sx={{ flexGrow: 1, fontWeight: "bold" }}
          >
            Contact Us
          </Typography>
          <Grid container rowSpacing={1} direction={"column"}>
            <Grid item >
                <img src={appStoreLogo} style={{maxWidth:"35%"}}/>
            </Grid>
            <Grid item >
                <img src={playStoreLogo} style={{maxWidth:"35%"}}/>
            </Grid>
          </Grid>
        </Grid>
      </Grid>
      <br />
      <Copyright />
    </Box>
  );
}
