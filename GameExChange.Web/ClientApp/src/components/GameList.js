import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';

import { actionCreators } from '../store/GameListStore';

//import './css/GameList.css';

import { Carousel, WingBlank } from 'antd-mobile';

class GameList extends Component {

    state = {
        data: ['1', '2', '3'],
        imgHeight: 176,
    }

    componentWillMount() {
        // This method runs when the component is first added to the page
        const pageIndex = parseInt(this.props.match.params.pageIndex, 10) || 0;
        this.props.requestGameDatas(pageIndex);

    }

    componentWillReceiveProps(nextProps) {
        // This method runs when incoming props (e.g., route params) change
        const pageIndex = parseInt(nextProps.match.params.pageIndex, 10) || 0;
        this.props.requestGameDatas(pageIndex);

    }
    componentDidMount() {
        //var slideWrapper = document.getElementsByClassName('main-slider');

        //if (slideWrapper.length > 0) {
        //    slideWrapper = slideWrapper[0];
        //    //start the slider
        //    slideWrapper.slick({
        //        // fade:true,
        //        autoplaySpeed: 4000,
        //        lazyLoad: "progressive",
        //        speed: 600,
        //        arrows: false,
        //        dots: true,
        //        cssEase: "cubic-bezier(0.87, 0.03, 0.41, 0.9)"
        //    });
        //}
        setTimeout(() => {
            this.setState({
                data: ['AiyWuByWklrrUDlFignR', 'TekJlZRVCjLFexlOCuWn', 'IJOtIlfsYdTyaDTRVrLI'],
            });
        }, 100);
    }

    render() {
        return (
            <WingBlank>
                <Carousel className="space-carousel"
                    frameOverflow="visible"
                    cellSpacing={10}
                    slideWidth={0.8}
                    autoplay
                    infinite
                    beforeChange={(from, to) => console.log(`slide from ${from} to ${to}`)}
                    afterChange={index => this.setState({ slideIndex: index })}
                >
                    {this.state.data.map((val, index) => (
                        <a
                            key={val}
                            href="http://www.alipay.com"
                            style={{
                                display: 'block',
                                position: 'relative',
                                top: this.state.slideIndex === index ? -10 : 0,
                                height: this.state.imgHeight,
                                boxShadow: '2px 1px 1px rgba(0, 0, 0, 0.2)',
                            }}
                        >
                            <img
                                src={`https://zos.alipayobjects.com/rmsportal/${val}.png`}
                                alt=""
                                style={{ width: '20%', height:'20%', verticalAlign: 'top' }}
                                onLoad={() => {
                                    // fire window resize event to change height
                                    window.dispatchEvent(new Event('resize'));
                                    this.setState({ imgHeight: 'auto' });
                                }}
                            />
                        </a>
                    ))}
                </Carousel>
            </WingBlank>
            //<div>
            //    <h1>Game List</h1>
            //    <p>It`s a Game List</p>
            //    {renderGameTable(this.props)}
            //</div>
        );
    }
}

var sliderSettings = {
    dots: true,
    infinite: true,
    speed: 500,
    slidesToShow: 1,
    slidesToScroll: 1
    //infinite: true,
    //autoplaySpeed: 4000,
    //lazyLoad: "progressive",
    //speed: 600,
    //arrows: false,
    //dots: true,
    //cssEase: "cubic-bezier(0.87, 0.03, 0.41, 0.9)"
};

function renderGameTable(props) {
    //console.log(props.results);
    return (

        <div>
            {
                props.results.map(obj =>
                    <div key={obj.id}>
                    </div>
                )
            }
        </div>
    );
}



//<div style={{ 'backgroundImage': 'https://drive.google.com/uc?export=view&id=0B_koKn2rKOkLRkY4S0JDTk1BbE0' }} >
//    <img data-lazy="https://drive.google.com/uc?export=view&id=0B_koKn2rKOkLRkY4S0JDTk1BbE0" />
//</div>
//    <div style={{ 'fontSize': 10 + 'px' }}>Static ImageStatic ImageStatic ImageStatic Image</div>

//<div className="item image">
//    <div className="slide-image slide-media show" style="background-image:url('https://drive.google.com/uc?export=view&id=0B_koKn2rKOkLRkY4S0JDTk1BbE0');">
//        <img data-lazy="https://drive.google.com/uc?export=view&id=0B_koKn2rKOkLRkY4S0JDTk1BbE0" class="image-entity" />
//    </div>
//    <div className="caption" style="font-size:10px">Static ImageStatic ImageStatic ImageStatic Image</div>
//</div>
//    <div class="item image">
//        <div className="slide-image slide-media show" style="background-image:url('https://drive.google.com/uc?export=view&id=0B_koKn2rKOkLNXBIcEdOUFVIWmM');">
//            <img data-lazy="https://drive.google.com/uc?export=view&id=0B_koKn2rKOkLNXBIcEdOUFVIWmM" class="image-entity" />
//        </div>
//        <div class="caption">Static Image</div>
//    </div>
//    <div className="item image">
//        <div class="slide-image slide-media show" style="background-image:url('https://drive.google.com/uc?export=view&id=0B_koKn2rKOkLSlBkWDBsWXJNazQ');">
//            <img data-lazy="https://drive.google.com/uc?export=view&id=0B_koKn2rKOkLSlBkWDBsWXJNazQ" class="image-entity" />
//        </div>
//        <div className="caption">Static Image</div>
//    </div>
//    <div className="item video">
//        <video className="slide-video slide-media show" loop muted preload="metadata" poster="https://drive.google.com/uc?export=view&id=0B_koKn2rKOkLSXZCakVGZWhOV00">
//            <source src="https://player.vimeo.com/external/138504815.sd.mp4?s=8a71ff38f08ec81efe50d35915afd426765a7526&profile_id=112" type="video/mp4" />
//        </video>
//        <p className="caption">HTML 5 Video</p>
//    </div>
//<table className='table'>
//    <thead>
//        <tr>
//            <th>Name</th>
//            <th>Type</th>
//            <th>Left</th>
//            <th></th>
//        </tr>
//    </thead>
//    <tbody>
//        {
//            props.results.map(obj =>
//                <tr key={obj.id}>
//                    <td>{obj.gameName}</td>
//                    <td>{obj.gameType}</td>
//                    <td>{obj.holdNum - obj.exchangedNum}</td>
//                    <td>
//                        <a className={"cur_p " + ((obj.holdNum - obj.exchangedNum) <= 0 ? '' : 'disabled')}
//                            to={`/GameDetail/${obj.id}`}
//                        >交换</a>
//                        &nbsp;&nbsp;
//                                <a className={"cur_p " + ((obj.holdNum - obj.exchangedNum) > 0 ? '' : 'disabled')}
//                            to={`/GameDetail/${obj.id}`}
//                        >借入</a>
//                    </td>
//                </tr>
//            )
//        }
//    </tbody>
//</table>


//<script type='text/javascript'>
//    var slideWrapper = document.getElementByClassName('main-slider');

//        </script>
          //  //start the slider
          //  slideWrapper.slick({
          //      // fade:true,
          //      autoplaySpeed:4000,
          //  lazyLoad:"progressive",
          //  speed:600,
          //  arrows:false,
          //  dots:true,
          //  cssEase:"cubic-bezier(0.87, 0.03, 0.41, 0.9)"
          //});


//function renderPagination(props) {
//    const prevStartDateIndex = (props.startDateIndex || 0) - 5;
//    const nextStartDateIndex = (props.startDateIndex || 0) + 5;

//    return <p className='clearfix text-center'>
//        <Link className='btn btn-default pull-left' to={`/fetchdata/${prevStartDateIndex}`}>Previous</Link>
//        <Link className='btn btn-default pull-right' to={`/fetchdata/${nextStartDateIndex}`}>Next</Link>
//        {props.isLoading ? <span>Loading...</span> : []}
//    </p>;
//}

export default connect(
    state => state.gameListStore,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(GameList);

