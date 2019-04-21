using BepInEx;
using BepInEx.Configuration;
using R2API;
using RoR2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassArtifact
{
    [BepInDependency("com.bepis.r2api", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin("com.lukeshep42.GlassArtifact", "GlassArtifact", "1.1.0")]
    public class GlassArtifact : BaseUnityPlugin
    {
        private void Awake()
        {
            float healthMultiplier;
            float damageMultiplier;

            float.TryParse(base.Config.Wrap("Settings", "healthMultiplier", "", "0.1").Value, out healthMultiplier);
            float.TryParse(base.Config.Wrap("Settings", "damageMultiplier", "", "5").Value, out damageMultiplier);

            Chat.AddMessage("Glass Artifact by lukeshep42 has loaded.");
            SurvivorAPI.SurvivorCatalogReady += delegate
            {
                foreach (SurvivorDef s in SurvivorAPI.SurvivorDefinitions)
                {
                    CharacterBody c = s.bodyPrefab.GetComponent<CharacterBody>();
                    c.baseMaxHealth *= (float)healthMultiplier;
                    c.levelMaxHealth *= (float)healthMultiplier;
                    c.baseDamage *= (float)damageMultiplier;
                    c.levelDamage *= (float)damageMultiplier;
                }
                BodyCatalog.FindBodyPrefab("EngiTurretBody").GetComponent<CharacterBody>().baseMaxHealth *= (float)healthMultiplier;
                BodyCatalog.FindBodyPrefab("EngiTurretBody").GetComponent<CharacterBody>().levelMaxHealth *= (float)healthMultiplier;
                BodyCatalog.FindBodyPrefab("EngiTurretBody").GetComponent<CharacterBody>().baseDamage *= (float)damageMultiplier;
                BodyCatalog.FindBodyPrefab("EngiTurretBody").GetComponent<CharacterBody>().levelDamage *= (float)damageMultiplier;
            };
        }
    }
}
