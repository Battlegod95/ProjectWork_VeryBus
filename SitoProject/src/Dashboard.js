import React, { Component } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Table  } from 'react-bootstrap';



class Dashboard extends Component {
  constructor(props) {
    super(props);
    this.state = {
      nPersone: ''
    };
  }

  componentWillMount() {
    const Influx = require('influx')

    // Connect to a single host with a full set of config details and
    // a custom schema
    const client = new Influx.InfluxDB({
      database: 'Verybus',
      host: 'localhost',
      port: 8086,
      username: 'Verybus',
      password: 'VMware1!',
      schema: [
        {
          measurement: 'DatiAutobus',
          fields: {
            ContaPersone: Influx.FieldType.INTEGER,
            Latitudine: Influx.FieldType.FLOAT,
            Longitudine: Influx.FieldType.FLOAT,
            Linea: Influx.FieldType.STRING,
          },
          tags: [
            'Linea',
            'TargaAutobus'
          ]
        }
      ]
    })

    client.query('select * from DatiAutobus where Linea = \'1\' ').then(results => {
   
      this.setState({
        nPersone: results
      })
    })
  }

  //componentDidMount(){}
  // componentWillUnmount(){}

  // componentWillReceiveProps(){}
  // shouldComponentUpdate(){}
  // componentWillUpdate(){}
  // componentDidUpdate(){}



  render() {
    const data = Array.from(this.state.nPersone);
    return (
      <div>
        <Table responsive id='table'>
          <thead>
            <tr>
              <th>Linea</th>
              <th>Numero di Persone</th>
              <th>Latitudine</th>
              <th>Longitudine</th>
            </tr>
          </thead>
          <tbody>
          {data.map(function (d, idx) {
            return (
              <tr>
                <td key={idx}>{d.Linea}</td> 
                <td key={idx}>{d.ContaPersone}</td>
                <td key={idx}>{d.Latitudine}</td>
                <td key={idx}>{d.Longitudine}</td> 
                <td key={idx}>{d.time}</td> 
              </tr>
            )
          })}
          </tbody>
        </Table >
      </div>
    );
  }
}

export default Dashboard;