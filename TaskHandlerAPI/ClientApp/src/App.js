import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import  TaskDefinition  from './components/task/task-definition';
import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route exact path='/taskdefinition' component={TaskDefinition} />
            </Layout>
        );
    }
}
