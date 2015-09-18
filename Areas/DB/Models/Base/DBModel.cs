using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BROWSit.Models
{
    public class RequirementDBModel
    {
        public Requirement requirement;
        public IEnumerable<Target> targets;
        public int myTarget;
        public string message;

        public RequirementDBModel(string p_message)
        {
            requirement = new Requirement();
            BROWSit.DAL.BROWSitContext db = new BROWSit.DAL.BROWSitContext();
            targets = db.Targets.ToList<Target>();
            message = p_message;
        }
    }

    public class PlatformDBModel
    {
        public Platform platform;
        public IEnumerable<Requirement> requirements;
        public int myRequirement;
        public string message;

        public PlatformDBModel(string p_message)
        {
            platform = new Platform();
            BROWSit.DAL.BROWSitContext db = new BROWSit.DAL.BROWSitContext();
            requirements = db.Requirements.ToList<Requirement>();
            message = p_message;
        }
    }

    public class TargetDBModel
    {
        public Target target;
        public int myTarget;
        public string message;

        public TargetDBModel(string p_message)
        {
            target = new Target();
            message = p_message;
        }
    }

    public class FeatureDBModel
    {
        public Feature feature;
        public int myTarget;
        public string message;

        public FeatureDBModel(string p_message)
        {
            feature = new Feature();
            message = p_message;
        }
    }
}