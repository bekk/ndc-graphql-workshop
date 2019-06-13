import React from 'react';
import { Query } from 'react-apollo';
import { GET_CHARACTERS } from './queries';
import { withRouter, Link } from 'react-router-dom';

const View = ({ characters }) => {
  // ToDo: Task 1c - show character image
  return (
    <>
      {characters.map(({ name }) => (
        <Link to={`/character/${name}`}>
          <div className="character-list-item" key={name}>
            {/* ToDo: Task 1c - insert img-tag here */}
            <h1>{name}</h1>
          </div>
        </Link>
      ))}
    </>
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
