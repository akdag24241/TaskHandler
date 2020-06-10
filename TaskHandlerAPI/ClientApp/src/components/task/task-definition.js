import React, { Component } from 'react';
import { Button, Form, FormGroup, Label, Input, FormText, Col, Progress } from 'reactstrap';
import { connect } from 'react-redux';
import { saveTask } from '../../redux/actions/task-definition'

class TaskDefinition extends Component {


    handleChange = (e) => {
        this.setState({
            [e.target.id]: e.target.id == "runPeriodId" ? parseInt(e.target.value) : e.target.value
        }, () => { console.log(this.state); });

    }
    handleFileChange = (e) => {
        if (e.target.files != null && e.target.files[0] != null) {
            const file = e.target.files[0];
            var reader = new FileReader();
            reader.onload = (evt) => {
                var binary = '';
                var bytes = new Uint8Array(reader.result);
                var len = bytes.byteLength;
                for (var i = 0; i < len; i++) {
                    binary += String.fromCharCode(bytes[i]);
                }
                const result = btoa(binary);
                this.setState({
                    base64FileContent: result
                });
            }
            reader.onprogress = (e) => {
                this.setState({
                    progress: parseInt(((e.loaded / e.total) * 100), 10)
                });
            }
            reader.readAsArrayBuffer(file);
        }
    }

    handleSubmit = (e) => {
        e.preventDefault();
        this.props.saveTask(this.state);
    }

    render() {
        if (!this.state) {
            this.state = {
                progress: 0,
                ...this.props.task
            };

        }
        return (
            <Form onSubmit={this.handleSubmit}>
                <FormGroup>
                    <Label for="exampleEmail">Task  Name</Label>
                    <Input type="text" name="name" id="name" placeholder="Task Name" onChange={this.handleChange} value={this.state.name} />
                </FormGroup>
                <FormGroup>
                    <Label for="exampleSelect">Works every minute</Label>
                    <Input type="select" name="runPeriodId" id="runPeriodId" onChange={this.handleChange} value={this.state.runPeriodId}>
                        <option value="0">Dakika</option>
                        <option value="1">Gün</option>
                    </Input>
                </FormGroup>
                <FormGroup>
                    <Label for="taskDescription">Description</Label>
                    <Input type="textarea" name="taskDescription" id="description" onChange={this.handleChange} value={this.state.description} />
                </FormGroup>
                <FormGroup row>
                    <Label for="exampleFile" sm={2}>File</Label>
                    <Col sm={10}>
                        <Input type="file" name="file" id="taskFileContent" onChange={this.handleFileChange} />
                        <FormText color="muted">
                            Choose your task file. It must be written in C# and must implement ITaskHelper
                        </FormText>
                    </Col>

                </FormGroup>
                <div>
                    <Progress value={this.state.progress} />
                </div>
                <Button onClick={this.handleSubmit}>Submit</Button>
            </Form>

        )

    }
}
const mapDispatchToProps = (dispatch) => {
    return {
        saveTask: (task) => dispatch(saveTask(task))
    }
}
const mapStateToProps = (state) => {
    return {
        task: state.task
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(TaskDefinition);