import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import styles from './App.module.css'

import TicketsNumberReport from "./components/Report/TicketsNumberReport";


export default class App extends Component {
  static displayName = App.name;

  render () {



      return (
      <Layout>
        <Route exact path='/' component={TicketsNumberReport} />
        <Route path='/tickets-number-report' component={TicketsNumberReport} />
      </Layout>
    );
  }
}
