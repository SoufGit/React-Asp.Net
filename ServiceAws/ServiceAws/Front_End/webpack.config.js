var webpack = require('webpack')
module.exports = {
    mode: 'development',
    context: __dirname,
    entry: "./src/index.js",
    output: {
        path: __dirname + "/dist",
        filename: "bundle.js"
    },
    watch: true,
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: "/(node_nodules)",
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: ['babel-preset-env', "babel-preset-react"],
                    }
                }
                //include: path.resolve(__dirname, 'src'),

                //query: {
                //    presets: ['react', 'es2015']
                //}
            },
            {
                test: /\.css$/,
                use: [
                    {
                        loader: 'style-loader',
                    },
                    {
                        loader: 'css-loader',
                        options: {
                            modules: true,
                            importLoaders: 1,
                            sourceMap: true,
                        },
                    },
                ]
            },
            { test: /\.svg$/, loader: 'svg-loader' },
            //resolve: {
            //    extensions: ['.css', '.js', '.es6']
            //}
            
        ],
    },
    plugins: [
        new webpack.optimize.ModuleConcatenationPlugin(),
        new webpack.DefinePlugin({
            'process.env': {
                NODE_ENV: JSON.stringify('production')
            }
        }),
        //new webpack.optimize.UglifyJsPlugin()
    ],
    resolve: {
                extensions: ['.css', '.js', '.es6']
            }
}