#load "utils.fsx"

open MathNet.Numerics.LinearAlgebra

let W = matrix [[0.2; -0.5; 0.1; 2.0; 1.0]
                [1.5; 1.3; 2.1; 0.0;1.0]
                [0.0; 0.25; 0.2; -0.3;1.0]]

let xi = matrix [[56.0]
                 [231.0]
                 [24.0]
                 [2.0]
                 [1.0]] 

/// X' is the augmented 3072 + 1 image data
let X' = matrix [[5.0; 3.0; 1.0; 2.0;  1.0]
                 [5.0; 3.0; 1.0; 2.0;  1.0]
                 [3.0; 1.0; 1.0; 2.0;  1.0]
                 [5.0; 3.0; 1.0; 2.0;  1.0]
                 [5.0; 3.0; 1.0; 2.0;  1.0]
                 [3.0; 1.0; 1.0; 2.0;  1.0]
                 [5.0; 3.0; 1.0; 2.0;  1.0]
                 [5.0; 3.0; 1.0; 2.0;  1.0]
                 [3.0; 1.0; 1.0; 2.0;  1.0]]

let Y = [|1; 2; 3; 4; 5; 6; 7; 8; 9|]
let scores = W * X'.Transpose()



let img = Utils.getRandomImageData()

let lbl = Utils.getRandomLabelsVector()

let weights = Utils.getRandomWeights()

let oneImage =  (img.SubMatrix (0, 1, 0, 3073)).Transpose() 


let LiV (x:Matrix<float>) (y:int) (W:Matrix<float>) =
  let delta = 1.0
  let scores = W.PointwiseMultiply(x)
  let margins = Matrix.map (fun s -> System.Math.Max(0.0, s - scores.[y,0] + delta) ) scores

  margins.[y,0] <- 0.0

  let lossI = Matrix.sum margins
  lossI




LiV oneImage 3 weights