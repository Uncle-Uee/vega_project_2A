using System.Collections.Generic;
using UnityEngine;

namespace CyberJellyFish.Editors
{
    public class TextureKeywords : ScriptableObject
    {
        [Header("Base Map Keys")]
        public List<string> BaseMapKeys = new List<string>()
        {
            "bmap",
            "bmap_",
            "b_map",
            "base",
            "basem",
            "base_m",
            "basemap",
            "base_map",
            "dmap",
            "dmap_",
            "d_map",
            "diff",
            "diff_",
            "diffm",
            "diff_m",
            "diffmap",
            "diff_map",
            "diffuse",
            "diffuse_",
            "diffusem",
            "diffuse_m",
            "diffusemap",
            "diffuse_map",
            "alb",
            "alb_",
            "albmap",
            "alb_map",
            "albm",
            "alb_m",
            "albedo",
            "albedo_",
            "albedom",
            "albedo_m",
            "albedomap",
            "albedo_map",
        };

        [Header("Metallic Map Keys")]
        public List<string> MetallicMapKeys = new List<string>()
        {
            "rough",
            "rough_",
            "roughm",
            "rough_m",
            "roughmap",
            "rough_map",
            "metal",
            "metal_",
            "metalm",
            "metal_m",
            "metalmap",
            "metal_map",
            "metallic",
            "metallic_",
            "metallicm",
            "metallic_m",
            "metallicmap",
            "metallic_map",
        };
        
        [Header("Specular Map Keys")]
        public List<string> SpecularMapKeys = new List<string>()
        {
            "spec",
            "spec_",
            "specm",
            "spec_m",
            "specmap",
            "spec_map",
        };

        [Header("Normal Map Keys")]
        public List<string> NormalMapKeys = new List<string>()
        {
            "nmap",
            "n_map",
            "nor",
            "nor_",
            "nor_m",
            "nor_map",
            "norm",
            "norm_map",
            "normal",
            "normal_map",
            "bmap",
            "b_map",
            "bump",
            "bumpm",
            "bump_m",
            "bump_map",
        };

        [Header("Occlusion Map Keys")]
        public List<string> OcclusionMapKeys = new List<string>()
        {
            "ao",
            "ao_",
            "aom",
            "ao_m",
            "aomap",
            "ao_map",
            "occlusion",
            "occlusionm",
            "occlusion_m",
            "occlusionmap",
            "occlusion_map",
        };
    }
}