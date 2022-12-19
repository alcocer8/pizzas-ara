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
                <Nav.Link as={Link} to="/">Home</Nav.Link>
                <Nav.Link as={Link} to="/employeesmanagement">Employees Management</Nav.Link>
                <Nav.Link as={Link} to="/productsmanagement">Products Management</Nav.Link>
                <Nav.Link as={Link} to="/ordersmanagement">Orders Management</Nav.Link>
                <Nav.Link as={Link} to="/">Logout</Nav.Link>
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