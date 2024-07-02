import * as React from "react";
import Card from "@mui/material/Card";
import CardActions from "@mui/material/CardActions";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";

export default function MediaCard({ title, description, image, price }) {
  return (
    <Card sx={{ maxWidth: 345, height: 470, position: "relative" }}>
      <CardMedia sx={{ height: 140 }} image={image} title="green iguana" />
      <CardContent>
        <Typography gutterBottom variant="h5" component="div">
          {title}
        </Typography>
        <Typography variant="body2" color="text.secondary">
          {description.length > 50
            ? description.substring(0, 80) + "..."
            : description}
        </Typography>
        <Typography
          color="red"
          variant="h5"
          sx={{
            fontWeight: "bold",
            position: "absolute",
            left: 40,
            bottom: 60,
          }}
        >
          {price}
          <span style={{ fontSize: "18px" }}> $</span>
        </Typography>
      </CardContent>
      <CardActions>
        <Button
          size="small"
          variant="contained"
          sx={{ position: "absolute", left: 15, bottom: 15 }}
        >
          <AddShoppingCartIcon fontSize="small" />
          <Typography fontSize={12}>Add to Cart</Typography>
        </Button>
        <Button
          size="small"
          sx={{ position: "absolute", right: 15, bottom: 15 }}
        >
          <Typography fontSize={12}>More</Typography>
        </Button>
      </CardActions>
    </Card>
  );
}
