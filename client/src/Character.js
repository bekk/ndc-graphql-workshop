import React from 'react';
import { withRouter } from 'react-router-dom';

class Character extends React.Component {
    render() {
        const id = this.props.match.params.id;

        return (
            <div>
                <h1>{id}</h1>
            </div>
        )
    }
}

export default withRouter(Character);