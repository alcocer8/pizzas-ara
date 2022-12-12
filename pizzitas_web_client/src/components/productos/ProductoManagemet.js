import React from "react";
import axios from "axios";
import { Button, Table } from "reactstrap";
//import "./ClientManagement.css";

import { Link, Navigate, useLocation } from "react-router-dom";

import { Alert, Container } from "reactstrap";

class ProductoManagement extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      items: [],
      itemsAccount: 25,
      searchTerm: "",
      isFetched: false,
      addEmpRedirect: false,
      token: props.token,
    };

    this.carrito = JSON.parse(localStorage.getItem("carrito")) || [];

    this.handle_change = this.handle_change.bind(this);

    this.BASEPATH = process.env.REACT_APP_END_POINT_PRODUCTO;
    this.GET_ALL = process.env.REACT_APP_END_POINT_PRODUCTO_ALL;
  }

  componentDidMount() {
    let url = this.BASEPATH + this.GET_ALL;

    url;
    axios
      .get(url, {
        headers: {
          "Content-type": "application/json; charset=utf-8",
          Authorization: "Bearer " + this.state.token,
          "Access-Control-Allow-Origin": true,
          "Access-Control-Allow-Credentials": true,
        },
      })
      .then((response) => {
        if (response.status === 200) {
          this.setState({ items: response.data, isFetched: true });
        }
      });
  }

  handle_change(e) {
    this.setState({
      result: e.target.checked,
    });
  }

  onChange = (e) => {
    e.preventDefault();
    this.setState({
      [e.target.name]: e.target.value,
    });
  };

  onFilterClick = (e) => {
    e.preventDefault();
  };

  onLoadItemsClick = (e) => {
    e.preventDefault();
  };

  onAddProductoClick = (e) => {
    e.preventDefault();

    this.setState({
      addEmpRedirect: true,
    });
  };

  agregarCarrito(e) {
    e.preventDefault();
    const productoObj = {
      id: document.querySelector("#idProducto"),
      name: document.querySelector("#name").textContent,
      descripcion: document.querySelector("#descripcion").textContent,
      cantidad: document.querySelector("#cantidad").textContent,
    };

    if (articulosCarrito.some((producto) => this.carrito.id === producto.id)) {
      const productos = articulosCarrito.map((producto) => {
        if (producto.id === producto.id) {
          let cantidad = parseInt(producto.cantidad);
          cantidad++;
          producto.cantidad = cantidad;
          return producto;
        } else {
          return producto;
        }
      });
      articulosCarrito = [...productos];
    } else {
      articulosCarrito = [...articulosCarrito, producto];
    }
  }

  addOrden (e) {
    e.preventDefault()
    let url = process.env.REACT_APP_END_POINT_DETALLES_ORDEN + process.env.REACT_APP_END_POINT_DETALLES_ORDEN_ALL;
    let id = e.target.parentNode.parentNode.querySelector("#idProducto").textContent
    let data = {
        iddetalles: 0,
        Idorden: 1,
        Idproducto: id,
        Quantity: 1
    }
    console.log(data)
    axios.post (url, JSON.stringify (data), {
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            //'Authorization': 'Bearer ' + state.token
        }
    })
    .then (response => {
        if (response.status === 200) {
            console.log("Se pudo")
        }
    })
}

  render() {
    if (this.state.addEmpRedirect) {
      return <Navigate to="/addProducto" />;
    }

    if (!this.state.isFetched) {
      return (
        <Container>
          <Alert color="primary">Loading....</Alert>
        </Container>
      );
    }

    return (
      <div>
        <Table striped bordered hover>
          <thead>
            <tr>
              <th>ID</th>
              <th>Name</th>
              <th>Description</th>
              <th>Precio</th>

              <th colSpan="2">Actions</th>
            </tr>
          </thead>
          <tbody>
            {this.state.items.map((item) => (
              <tr key={item.idproducto}>
                <td id="idProducto">{item.idproducto}</td>
                <td id="name">{item.name}</td>
                <td id={"descripcion"}> {item.descripcion}</td>
                <td id={"precio"}> {item.precio}</td>

                <td>
                  <button onClick={this.addOrden}>Agregar Carrito</button>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      </div>
    );
  }
}

//other necessary hack to get around react-router v6
//heavy hooks utlization
function WithRouter(Component) {
  function ComponentWithRouterProps(props) {
    let location = useLocation();
    return <Component {...props} {...{ location }} />;
  }

  return ComponentWithRouterProps;
}

export default WithRouter(ProductoManagement);
