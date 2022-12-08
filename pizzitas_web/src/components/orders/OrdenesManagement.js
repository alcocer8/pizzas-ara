import React from "react";
import axios from "axios";
import { Button, Table } from "reactstrap";
//import "./employeesManagement.css";

import { Link, Navigate, useLocation } from "react-router-dom";

import { Alert, Container } from "reactstrap";

class OrdenesManagement extends React.Component {
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

    this.handle_change = this.handle_change.bind(this);

    this.BASEPATH = process.env.REACT_APP_END_POINT_DETALLES_ORDEN;
    this.GET_ALL = process.env.REACT_APP_END_POINT_DETALLES_ORDEN_ALL;
  }

  componentDidMount() {
    let url = this.BASEPATH + this.GET_ALL;
    console.log(url);
    axios
      .get(url, {
        headers: {
          "Content-type": "application/json; charset=utf-8",
          Authorization: "Bearer " + this.state.token,
          "Access-Control-Allow-Origin": true,
          "Access-Control-Allow-Credentials": true,
        },
      })
      .then(
        (response) => {
          if (response.status === 200) {
            this.setState({ items: response.data, isFetched: true });
          }
        },
        (error) => {
          //console.error ("error -> ", error);
        }
      )
      .catch((ex) => {
        //console.error ("ERROR: ", ex);
      });
  }

  handle_change(e) {
    console.log(e.target.checked);

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

  onChangeEstado = (e) => {
    let data = {
      idOrden: e.target.parentElement.parentElement.id,
      idCondicion: e.target.value,
    };
    let url =
      process.env.REACT_APP_END_POINT_ORDEN +
      process.env.REACT_APP_END_POINT_ORDEN_ALL;

    axios
      .put(url, JSON.stringify(data), {
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          Authorization: "Bearer " + this.state.token,
        },
      })
      .then((response) => {
        if (response.status === 200) {
          console.log("paso");
          console.log(response);
          return;
        }
      })
      .catch((reason) => {});
  };

  render() {
    if (this.state.token === "" || this.state.token === null) {
      return (
        <Navigate to="/login" state={{ from: this.props.location.pathname }} />
      );
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
        <form>
          <input
            type="text"
            name="itemsAccount"
            id="itemsAccount"
            value={this.state.itemsAccount}
            onChange={this.onChange}
          />
          &nbsp;
          <Button onClick={this.onLoadItemsClick}>Load Items</Button>
        </form>
        <form>
          <input
            type="text"
            name="searchTerm"
            id="searchTerm"
            onChange={this.onChange}
          />
          &nbsp;
          <Button onClick={this.onFilterClick}>Filter</Button>
        </form>
        &nbsp;
        <Table striped bordered hover>
          <thead>
            <tr>
              <th>ID Order</th>
              <th>fullName</th>
              <th>producto</th>
              <th>cantidad</th>
              <th>fecha</th>
              <th>Estado</th>
              <th colSpan="2">Actions</th>
            </tr>
          </thead>
          <tbody>
            {this.state.items.map((item) => (
              <tr key={item.idOrden} id={item.idOrden}>
                <td>{item.idOrden}</td>
                <td>{item.fullName}</td>
                <td>{item.producto}</td>
                <td>{item.cantidad}</td>
                <td>{item.fecha}</td>
                <td>{item.estado}</td>
                <td>
                  {/* <Link to={`/edit/producto/${item.idproducto}`}>Edit</Link> */}
                  <select onChange={this.onChangeEstado}>
                    <option value="1">Pendiente</option>
                    <option value="2">En Preparacion</option>
                    <option value="3">Enviado</option>
                    <option value="4">Entregado</option>
                  </select>
                </td>
                <td>Delete</td>
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

export default WithRouter(OrdenesManagement);
