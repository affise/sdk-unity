platform :ios, '11.0'

target 'UnityFramework' do
   pod 'AffiseAttributionLib', '1.1.6'
end

target 'Unity-iPhone' do
end

use_frameworks! :linkage => :static
