import React from 'react';
import axios from 'axios';
import { Button, Table } from 'reactstrap';
import './ClientManagement.css';

import { Link, Navigate, useLocation } from 'react-router-dom';

import { Alert, Container }  from 'reactstrap';

class ClientManagement extends React.Component {

    constructor (props) {
        super (props);    
        
        this.state = {
            items: [],
            itemsAccount: 25,
            searchTerm: '',
            isFetched: false,
            addEmpRedirect: false,
            token: props.token
        };
        
        this.handle_change = this.handle_change.bind (this);

        this.BASEPATH = process.env.REACT_APP_END_POINT_CLIENTE;
        this.GET_ALL = process.env.REACT_APP_END_POINT_CLIENTE_ALL;
    }

    componentDidMount () {
        let url = this.BASEPATH + this.GET_ALL;

        axios.get (url, {
            headers: {
                'Content-type': 'application/json; charset=utf-8',
                'Authorization': 'Bearer ' + this.state.token,
                'Access-Control-Allow-Origin': true,
                'Access-Control-Allow-Credentials': true
            }
        })
        .then ((response) => {
            if (response.status === 200) {
                this.setState ({ items: response.data, isFetched: true })
            }
        }, (error) => {
            //console.error ("error -> ", error);
        })
        .catch ((ex) => {
            //console.error ("ERROR: ", ex);
        });
    }

    handle_change (e) {
        (e.target.checked);

        this.setState ({
            result: e.target.checked
        });
    }

    onChange = (e) => {
        e.preventDefault ();
        
        this.setState (
            {
                [e.target.name] : e.target.value
            }
        );
    }

    onFilterClick = (e) => {
        e.preventDefault ();
    }

    onLoadItemsClick = (e) => {
        e.preventDefault ();
    }

    onAddEmployeeClick = (e) => {
        e.preventDefault ();
        
        this.setState (
            {
                addEmpRedirect: true
            }
        )
    }

    render () { 

        if (this.state.addEmpRedirect) {
            return (
                <Navigate to = '/addEmployee' />
            );
        }

        if (this.state.token === '' || this.state.token === null) {
            return (
                <Navigate to = '/login' state={{from: this.props.location.pathname}} />
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
                    <input type='text' name='itemsAccount' id='itemsAccount' value={this.state.itemsAccount} onChange={this.onChange} />
                    &nbsp;
                    <Button onClick={this.onLoadItemsClick}>Load Items</Button>
                    <Button className='float-end' onClick={this.onAddEmployeeClick}>Add Employee</Button>
                </form>
                <form>
                    <input type='text' name='searchTerm' id='searchTerm' onChange={this.onChange} />
                    &nbsp;
                    <Button onClick={this.onFilterClick} >Filter</Button>
                </form>
                &nbsp;
                <Table striped bordered hover>
                    <thead>
                        <tr>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Ceuluar</th>
                            <th>Username</th>
                            <th colSpan='2'>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.state.items.map (item => 
                                <tr key={item.idempleado}>
                                    <td>{item.name}</td>
                                    <td>{item.lastname}</td>
                                    <td>{item.celular}</td>
                                    <td>{item.username}</td>
                                    <td><Link to={`/edit/${item.idempleado}`}>Edit</Link></td>
                                </tr>
                            )
                        }
                    </tbody>          
                </Table>
            </div>

        );

    }

}

//other necessary hack to get around react-router v6
//heavy hooks utlization
function WithRouter (Component) {
    function ComponentWithRouterProps (props) {
        let location = useLocation ();
        return (
            <Component {...props}{...{location}} />
        )
    }

    return ComponentWithRouterProps;
}

export default WithRouter (ClientManagement);