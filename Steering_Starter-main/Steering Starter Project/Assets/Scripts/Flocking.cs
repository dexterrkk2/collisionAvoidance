using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : Kinematic
{
    BlendedSteering myMoveType;
    public float weight1;
    public float weight2;
    public float weight3;
    public float weight4;
    public bool flee = false;
    public List<Kinematic> targets;
    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new BlendedSteering();
        myMoveType.behaviours = new List<BehaviourandWeight>();
        WeightSetup();
        myMoveType.character = this;
        myMoveType.target = myTarget;
        myMoveType.flee = flee;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate = myMoveType.getSteering();
        base.Update();
    }
    public void WeightSetup() 
    {
        BehaviourandWeight SeperationWeight = new BehaviourandWeight();
        Separation seperation = new Separation();
        seperation.targets = targets;
        seperation.character = this;
        SeperationWeight.Behavior = seperation;
        SeperationWeight.weight = weight1;
        myMoveType.behaviours.Add(SeperationWeight);
        Cohesion cohesion = new Cohesion();
        cohesion.targets = targets;
        cohesion.character = this;
        BehaviourandWeight cohesioWeighted = new BehaviourandWeight();
        cohesioWeighted.Behavior = cohesion;
        cohesioWeighted.weight = weight2;
        myMoveType.behaviours.Add(cohesioWeighted);
        Debug.Log("Weights Setup");
        Align align = new Align();
        align.target = myTarget;
        align.character = this;
        BehaviourandWeight AlighnWeight = new BehaviourandWeight();
        AlighnWeight.Behavior = align;
        AlighnWeight.weight = weight3;
        myMoveType.behaviours.Add(AlighnWeight);
        Pursue seek = new Pursue();
        seek.target = myTarget;
        seek.character = this;
        BehaviourandWeight SeekWeight = new BehaviourandWeight();
        SeekWeight.Behavior = seek;
        SeekWeight.weight = weight4;
        myMoveType.behaviours.Add(SeekWeight);
    }

}
