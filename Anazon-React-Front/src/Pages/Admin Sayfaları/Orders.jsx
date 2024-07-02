import * as React from "react";
import CssBaseline from "@mui/material/CssBaseline";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";

import Container from "@mui/material/Container";
import Grid from "@mui/material/Grid";
import Paper from "@mui/material/Paper";

import Copyright from "../../Components/Copyright";
import DashboardAppBar from "../../Components/DashboardAppBar";
import OrdersTable from "../../Components/OrdersTable";

export default function Orders() {
  return (
    <Box sx={{ display: "flex" }}>
      <CssBaseline />
      <DashboardAppBar pageTitle="Orders" />
      <Box
        component="main"
        sx={{
          backgroundColor: (theme) =>
            theme.palette.mode === "light"
              ? theme.palette.grey[100]
              : theme.palette.grey[900],
          flexGrow: 1,
          height: "100vh",
          overflow: "auto",
        }}
      >
        <Toolbar />
        <Container maxWidth="lg" sx={{ mt: 4, mb: 4 }}>
          {/* Orders */}
          <Paper sx={{ p: 2, display: "flex", flexDirection: "column" }}>
            <OrdersTable />
          </Paper>
        </Container>
        <Copyright sx={{ pt: 4 }} />
      </Box>
    </Box>
  );
}
