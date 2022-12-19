import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom';

//Importamos los components creados
import NavBarExample from './components/layouts/navbar';
import Home from './components/Home';
import EmployeesManagement from './components/EmployeesManagement';
import ProductsManagement from './components/ProductsManagement';
import OrdersManagement from './components/OrdersManagement';
import Employees from './components/Employees';
import AddEmployees from './components/AddEmployees';
import EditEmployees from './components/EditEmployees';
import EditProduct from './components/EditProduct';
import AddProduct from './components/AddProduct';


function App() {
  return (
        <div className="App">
    <BrowserRouter>
    <Routes>
      <Route path='/' element={ <NavBarExample /> }>
        <Route index element={ <Home /> } />
        <Route path='employeesmanagement' element={ <EmployeesManagement/> } />
        <Route path='productsmanagement' element={ <ProductsManagement/> } />
        <Route path='ordersmanagement' element={ <OrdersManagement/> } />
        <Route path='employees' element={ <Employees/> } />
        <Route path='addemployees' element={ <AddEmployees/> } />
        <Route path='editemployees' element={ <EditEmployees/> } />
        <Route path='editproduct' element={ <EditProduct/> } />
        <Route path='addproduct' element={ <AddProduct/> } />

        <Route path='*' element={ <Navigate replace to="/"/> }/>
      </Route>
    </Routes> 
    </BrowserRouter>
    </div>
  );
}
export default App;