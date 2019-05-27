import React from 'react';
import { Query } from 'react-apollo';
import { GET_CHARACTERS } from './queries';
import { withRouter, Link } from 'react-router-dom';

class Characters extends React.Component {
    render() {
        return (
            <Query query={GET_CHARACTERS}>
                {({ loading, error, data }) => {
                    if (loading) {
                        return <h1>Laster...</h1>;
                    }

                    if (error) {
                        return <h1>Error!</h1>;
                    }

                    return (
                        <ul>
                            {data.characters.map(({ id, name, image }) => (
                                <li key={name}>
                                    <Link to={`/character/${id}`}>
                                        <img src={image} />
                                        <span>{name}</span>
                                    </Link>
                                </li>
                            ))}
                        </ul>
                    )
                }}
            </Query>
        )
    }
}

export default withRouter(Characters);