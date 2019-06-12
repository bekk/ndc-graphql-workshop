import React from 'react';
import { Query } from 'react-apollo';
import { GET_CHARACTERS } from './queries';
import { withRouter, Link } from 'react-router-dom';

const View = ({ characters }) => {
  return (
    <ul>
      {characters.map(({ name, image }) => (
        <li key={name}>
          <Link to={`/character/${name}`}>
            <img src={image} alt="" />
            <span>{name}</span>
          </Link>
        </li>
      ))}
    </ul>
  );
};

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

          return <View characters={data.characters} />;
        }}
      </Query>
    );
  }
}

export default withRouter(Characters);
