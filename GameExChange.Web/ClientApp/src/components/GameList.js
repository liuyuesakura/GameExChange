import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';


class GameList extends Component {
    //componentWillMount() {
    //    // This method runs when the component is first added to the page
    //    const startDateIndex = parseInt(this.props.match.params.startDateIndex, 10) || 0;
    //    this.props.requestWeatherForecasts(startDateIndex);
    //}

    //componentWillReceiveProps(nextProps) {
    //    // This method runs when incoming props (e.g., route params) change
    //    const startDateIndex = parseInt(nextProps.match.params.startDateIndex, 10) || 0;
    //    this.props.requestWeatherForecasts(startDateIndex);
    //}

    render() {
        return (
            <div>
                <h1>Game List</h1>
                <p>It`s a Game List</p>
            </div>
        );
    }
}

export default connect(
    state => state.GameList,
    //dispatch => bindActionCreators(actionCreators, dispatch)
)(GameList);

                //{renderForecastsTable(this.props)}
                //{renderPagination(this.props)}