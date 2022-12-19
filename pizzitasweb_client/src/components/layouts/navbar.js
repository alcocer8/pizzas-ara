import { Navbar, Nav, Container } from "react-bootstrap"
import { Outlet, Link } from "react-router-dom"
import '../css/inicio.css'
import logo from '../../assets/pizzitaswhite.png'

const NavBarExample = () => {
    return (
      <>
      <Navbar className="nav" variant="dark" >
        
        <Container>
            <Navbar.Brand as={Link} to="/" ></Navbar.Brand>
            <Navbar.Toggle aria-controls="collapse navbar-collapse" />
            <Navbar.Collapse id="basic-navbar-nav ">
            <Nav className="navbar-nav me-auto" >
                <Nav.Link as={Link} to="/">Inicio</Nav.Link>
                <Nav.Link as={Link} to="/ordenes">Ordenes</Nav.Link>
                <Nav.Link as={Link} to="/contacto">Contacto</Nav.Link>
                <Nav.Link as={Link} to="/login"><i className="bi bi-person-badge-fill"></i> Iniciar Sesion </Nav.Link>
                <Nav.Link as={Link} to="/carrito"><i className="bi bi-cart-check-fill"></i> Carrito </Nav.Link>                     
            </Nav>
            </Navbar.Collapse>
            
        </Container>
        <div className="logo">
        <img src={logo} alt=""/>
        </div>
        
        </Navbar> 
        <section>
            <Outlet></Outlet>
        </section>   
      </>
    )
  }
  
  export default NavBarExample